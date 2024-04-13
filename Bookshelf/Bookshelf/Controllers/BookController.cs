using Bookshelf.Models;
using Bookshelf.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Bookshelf.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly string _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Beholder13;Database=bookshelf";
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var repository = new BookRepository(new NpgsqlConnection(_connectionString));

        return Ok(repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var repository = new BookRepository(new NpgsqlConnection(_connectionString));

        return Ok(repository.GetById(id));
    }
    
    [HttpPost()]
    public IActionResult Create(Book book)
    {
        var repository = new BookRepository(new NpgsqlConnection(_connectionString));

        return Ok(repository.Create(book));
    }
    
    [HttpPut()]
    public IActionResult Update(Book book)
    {
        var repository = new BookRepository(new NpgsqlConnection(_connectionString));
        repository.Update(book);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var repository = new BookRepository(new NpgsqlConnection(_connectionString));
        repository.Delete(id);

        return Ok();
    }
}