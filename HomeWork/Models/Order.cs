namespace HomeWork.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public int PhoneId { get; set; }
    public Phone Phone { get; set; }
}