using Dot6.API.Crud.Data.Entities;
using Microsoft.EntityFrameworkCore;


public class TestNectiaDbContext : DbContext
{
    public TestNectiaDbContext(DbContextOptions<TestNectiaDbContext> options) : base(options)
    {

    }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }

}