using FluentValidation.Results;
using HomeWork.Models;
using HomeWork.Service.Abstract;
using HomeWork.Validation;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly CreateOrderValidation _createOrderValidation;
    private readonly CreateOrder _createOrder;

    public OrderController(IOrderService orderService, CreateOrderValidation createOrderValidation, CreateOrder createOrder)
    {
        _orderService = orderService;
        _createOrderValidation = createOrderValidation;
        _createOrder = createOrder;
    }
    [HttpGet]
    public IActionResult Create(int id)
    {
        var phone = _orderService.GetPhoneById(id);

        if (string.IsNullOrEmpty(phone.Title))
            return NotFound();
        _createOrder.Order.Phone = phone;
        
        return View(_createOrder);
    }
    
    [HttpPost]
    public IActionResult Create(CreateOrder createOrder)
    {
        ValidationResult validate = _createOrderValidation.Validate(createOrder.Order);
        if (validate.IsValid)
        {
            _orderService.Add(createOrder.Order);
            return RedirectToAction("Orders");
        }
        
        createOrder.ErrorViewModel.Errors = validate.Errors;
        var phone = _orderService.GetPhoneById(createOrder.Order.PhoneId);
        createOrder.Order.Phone = phone;
        return View(createOrder);
    }

    public IActionResult Orders()
    {
        var orders = _orderService.GetAll();
        return View(orders);
    }
}