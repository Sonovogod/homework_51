using HomeWork.Models;
using HomeWork.Service.Abstract;

namespace HomeWork.Service;

public class PhoneService : IPhoneService
{
    private readonly PhoneContext _db;

    public PhoneService(PhoneContext db)
    {
        _db = db;
    }

    public List<Phone> GetAll()
    {
        List<Phone> phones = _db.Phone.ToList();
        return phones;
    }

    public Phone GetPhone(int id)
    {
        var phones = GetAll();
        return phones.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Phone phone)
    {
        _db.Phone.Add(phone);
        _db.SaveChanges();
    }
}