using Dot6.API.Crud.Data;
using Dot6.API.Crud.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class VehiculoController : ControllerBase
{
    private readonly TestNectiaDbContext _TestDbContext;
    public VehiculoController(TestNectiaDbContext TestNectiaDbContext)
    {
        _TestDbContext = TestNectiaDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var cakes = await _TestDbContext.Vehiculo.ToListAsync();
        return Ok(cakes);
    }

    [HttpGet]
    [Route("get-vehiculo-by-id")]
    public async Task<IActionResult> GetCakeByIdAsync(int id)
    {
        var cake = await _TestDbContext.Vehiculo.FindAsync(id);
        return Ok(cake);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Vehiculo vehiculo)
    {
        _TestDbContext.Vehiculo.Add(vehiculo);
        await _TestDbContext.SaveChangesAsync();
        return Created($"/get-vehiculo-by-id?id={vehiculo.Id}", vehiculo);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Vehiculo vehiculoToUpdate)
    {
        _TestDbContext.Vehiculo.Update(vehiculoToUpdate);
        await _TestDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var vehiculoToDelete = await _TestDbContext.Vehiculo.FindAsync(id);
        if (vehiculoToDelete == null)
        {
            return NotFound();
        }
        _TestDbContext.Vehiculo.Remove(vehiculoToDelete);
        await _TestDbContext.SaveChangesAsync();
        return NoContent();
    }
}