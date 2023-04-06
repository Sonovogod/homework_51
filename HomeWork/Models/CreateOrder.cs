using HomeWork.Controllers;

namespace HomeWork.Models;

public class CreateOrder
{
    public Order Order { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public CreateOrder()
    {
        ErrorViewModel = new ErrorViewModel();
        Order = new Order();
    }
}