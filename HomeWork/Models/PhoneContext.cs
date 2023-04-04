using HomeWork.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Service;

public class PhoneContext : DbContext
{
    public DbSet<Phone> Phone { get; set; }
    public DbSet<Order> Order { get; set; }
}