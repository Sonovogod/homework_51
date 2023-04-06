using HomeWork.Models;
using HomeWork.Service;
using HomeWork.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    public IActionResult Create(int id)
    {
        var phone = _orderService.GetPhoneById(id);

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
        _orderService.Add(order);
        return RedirectToAction("Orders");
    }

    public IActionResult Orders()
    {
        var orders = _orderService.GetAll();
        return View(orders);
    }
}