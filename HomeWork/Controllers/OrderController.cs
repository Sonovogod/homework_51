using HomeWork.Models;
using HomeWork.Service;
using HomeWork.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Controllers;

public class OrderController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly PhoneContext _db;

    public OrderController(IPhoneService phoneService, PhoneContext db)
    {
        _phoneService = phoneService;
        _db = db;
    }
    [HttpGet]
    public IActionResult Create(int id)
    {
        var phone = _phoneService.GetPhone(id);

        if (string.IsNullOrEmpty(phone.Title))
            return NotFound();
        Order order = new Order()
        {
            Phone = phone
        };
        return View(order);
    }
    
    [HttpPost]
    public IActionResult Create(Order order)
    {
        _db.Order.Add(order);
        _db.SaveChanges();
        return RedirectToAction("Orders");
    }

    public IActionResult Orders()
    {
        var orders = _db.Order
            .Include(x => x.Phone)
            .ToList();
        return View(orders);
    }
}