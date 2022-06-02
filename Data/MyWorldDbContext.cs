using Dot6.API.Crud.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot6.API.Crud.Data;

public class TestNectiaDbContext : DbContext
{
    public TestNectiaDbContext(DbContextOptions<TestNectiaDbContext> options) : base(options)
    {

    }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }

}