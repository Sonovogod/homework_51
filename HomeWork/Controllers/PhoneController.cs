using HomeWork.Models;
using HomeWork.Service;
using HomeWork.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers;

public class PhoneController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly CreatePhoneValidator _createPhoneValidator;
    
    
    public PhoneController(IPhoneService phoneService, CreatePhoneValidator createPhoneValidator)
    {
        _phoneService = phoneService;
        _createPhoneValidator = createPhoneValidator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Phone> phones = _phoneService.GetAll();
        return View(phones);
    }

    [HttpGet]
    public IActionResult Create()
    {
        
        return View();
    }
}