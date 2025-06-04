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
    public async Task<IActionResult> GetOrders(int OrderId)
    {
        var order =  await _dbService.GetOrder(OrderId);
        return Ok(order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrders(int orderId, FulfillOrderDto fulfillOrderDto)
    {
        await _dbService.FulfillOrder(orderId, fulfillOrderDto);
        return Ok();
    }
    
}