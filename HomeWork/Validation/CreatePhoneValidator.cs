using FluentValidation;
using HomeWork.Models;

namespace HomeWork.Validation;

public class CreatePhoneValidator : AbstractValidator<Phone>
{
    public CreatePhoneValidator()
    {
        RuleFor(phone => phone.Title)
            .MinimumLength(1).WithMessage("Слишком короткое название модели")
            .MaximumLength(20).WithMessage("Слишком длинное название модели")
            .NotEmpty().WithMessage("Название модели не должно быть пустым");
        RuleFor(phone => phone.Manufacture)
            .MinimumLength(1).WithMessage("Слишком короткое название производителя")
            .MaximumLength(20).WithMessage("Слишком длинное название производителя")
            .NotEmpty().WithMessage("Название производителя не должно быть пустым");
        RuleFor(phone => phone.Description)
            .MaximumLength(100)
            .WithMessage("Описание не более 100 символов")
            .MinimumLength(10)
            .WithMessage("Описание не менее 10 символов")
            .NotEmpty().WithMessage("Описание не должно быть пустым");
        RuleFor(phone => phone.Coast)
            .GreaterThan(0).WithMessage("Стоимость должна быть больше 0");
    }
}