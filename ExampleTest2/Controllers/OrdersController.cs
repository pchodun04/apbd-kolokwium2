using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrders(int customerId)
    {
        try
        {
            var order =  await _dbService.GetOrder(customerId);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        
    }

    
    
    
}