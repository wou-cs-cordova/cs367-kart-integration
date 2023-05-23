using Microsoft.EntityFrameworkCore;
using SmartKart.Web.Models;

namespace SmartKart.Web.Data;

public class SmartKartContext : DbContext
{
    public SmartKartContext(DbContextOptions<SmartKartContext> options)
        : base(options)
    {
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Kart>? Karts { get; set; }
    public DbSet<KartItem>? KartItems { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
}