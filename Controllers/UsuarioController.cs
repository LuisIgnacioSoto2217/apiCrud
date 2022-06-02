using Dot6.API.Crud.Data;
using Dot6.API.Crud.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dot6.API.Crud.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly TestNectiaDbContext _TestDbContext;
    public UsuarioController(TestNectiaDbContext TestNectiaDbContext)
    {
        _TestDbContext = TestNectiaDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var cakes = await _TestDbContext.Usuario.ToListAsync();
        return Ok(cakes);
    }

    [HttpGet]
    [Route("get-usuario-by-id")]
    public async Task<IActionResult> GetCakeByIdAsync(int id)
    {
        var cake = await _TestDbContext.Usuario.FindAsync(id);
        return Ok(cake);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Usuario Usuario)
    {
        _TestDbContext.Usuario.Add(Usuario);
        await _TestDbContext.SaveChangesAsync();
        return Created($"/get-usuario-by-id?id={Usuario.Id}", Usuario);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Usuario UsuarioToUpdate)
    {
        _TestDbContext.Usuario.Update(UsuarioToUpdate);
        await _TestDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var UsuarioToDelete = await _TestDbContext.Usuario.FindAsync(id);
        if (UsuarioToDelete == null)
        {
            return NotFound();
        }
        _TestDbContext.Usuario.Remove(UsuarioToDelete);
        await _TestDbContext.SaveChangesAsync();
        return NoContent();
    }
}