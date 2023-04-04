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
}