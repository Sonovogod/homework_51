using HomeWork.Models;

namespace HomeWork.Service.Abstract;

public interface IPhoneService
{
    public List<Phone> GetAll();
    public Phone GetPhone(int id);
    public void Add(Phone phone);
}