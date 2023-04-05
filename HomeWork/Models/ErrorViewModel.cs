using FluentValidation.Results;

namespace HomeWork.Models;

public class ErrorViewModel
{
    public List<ValidationFailure> Errors { get; set; }

    public ErrorViewModel()
    {
        Errors = new List<ValidationFailure>();
    }
    
}