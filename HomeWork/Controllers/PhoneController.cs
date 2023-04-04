using HomeWork.Models;
using HomeWork.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers;

public class PhoneController : Controller
{
    private readonly IPhoneService _phoneService;
    
    
    public PhoneController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Phone> phones = _phoneService.GetAll();
        return View(phones);
    }
}