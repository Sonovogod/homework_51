namespace HomeWork.Models;

public class CreatePhone
{
    public Phone Phone { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public CreatePhone()
    {
        ErrorViewModel = new ErrorViewModel();
    }
}