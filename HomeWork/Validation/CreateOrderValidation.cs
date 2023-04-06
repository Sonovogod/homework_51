using System.Text.RegularExpressions;
using FluentValidation;
using HomeWork.Models;

namespace HomeWork.Validation;

public class CreateOrderValidation : AbstractValidator<Order>
{
    public CreateOrderValidation()
    {
        RuleFor(order => order.Name)
            .MinimumLength(1).WithMessage("Слишком короткое имя")
            .MaximumLength(20).WithMessage("Слишком длинное имя")
            .NotEmpty().WithMessage("Имя не должно быть пустым");
        RuleFor(order => order.PhoneNumber)
            .NotEmpty().WithMessage("Номер должен быть указан");
    }
}