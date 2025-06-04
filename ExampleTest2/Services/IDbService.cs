using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<OrderDto> GetOrder(int orderId);
    Task FulfillOrder(int orderId,  FulfillOrderDto fulfillOrderDto);
}