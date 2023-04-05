using FluentValidation.Results;
using HomeWork.Models;
using HomeWork.Service;
using HomeWork.Service.Abstract;
using HomeWork.Validation;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers;

public class PhoneController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly CreatePhoneValidator _createPhoneValidator;
    private readonly CreatePhone _createPhone;
    
    
    public PhoneController(IPhoneService phoneService, CreatePhoneValidator createPhoneValidator, CreatePhone createPhone)
    {
        _phoneService = phoneService;
        _createPhoneValidator = createPhoneValidator;
        _createPhone = createPhone;
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
        return View(_createPhone);
    }

    [HttpPost]
    public IActionResult Create(Phone phone)
    {
        ValidationResult validator = _createPhoneValidator.Validate(phone);

        if (validator.IsValid)
            _phoneService.Add(phone);
        else
        {
            _createPhone.ErrorViewModel.Errors = validator.Errors;
            return View(_createPhone);
        }

        return RedirectToAction("Index");
    }
}