using HomeWork.Models;
using HomeWork.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Service;

public class OrderService : IOrderService
{
    private readonly PhoneContext _db;

    public OrderService(PhoneContext db)
    {
        _db = db;
    }

    public void Add(Order order)
    {
        _db.Order.Add(order);
        _db.SaveChanges();
    }

    public Phone GetPhoneById(int id)
    {
        var phone = _db.Phone.FirstOrDefault(x => x.Id == id);
        return phone;
    }

    public List<Order> GetAll()
    {
        var orders = _db.Order
            .Include(x => x.Phone)
            .ToList();

        return orders;
    }
}