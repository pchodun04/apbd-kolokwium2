using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<OrderDto> GetOrder(int customerId);
    Task<bool> DoesCustomerExist(int customerId);
    Task<bool> DoesConcertExist(string concertName);
    Task<bool> DoesCustomerHasMoreThan5Tickets(int customerId);
}