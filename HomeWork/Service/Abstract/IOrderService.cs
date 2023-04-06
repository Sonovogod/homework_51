using HomeWork.Models;

namespace HomeWork.Service.Abstract;

public interface IOrderService
{
    public void Add(Order order);
    Phone GetPhoneById(int id);
    List<Order> GetAll();
}