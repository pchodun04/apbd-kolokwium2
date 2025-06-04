using System.Data;
using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<OrderDto> GetOrder(int customerId)
    {
        var order = await _context.Customers
            .Select(e => new OrderDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            Purchases = e.PurchasedTickets.Select(s => new PurchaseDto()
            {
                PurchaseDate = s.PurchaseDate,
                Price = s.TicketConcert.Price,
                Ticket = new TicketDto()
                {
                    SerialNumber = s.TicketConcert.Ticket.SerialNumber,
                    SeatNumber = s.TicketConcert.Ticket.SeatNumber
                },
                Concert = new ConcertDto()
                {
                    Name = s.TicketConcert.Concert.Name,
                    Date = s.TicketConcert.Concert.Date,
                }
                
            }).ToList()
        }).FirstOrDefaultAsync(e => e.Id == customerId);

        if (order is null)
        {
            throw new NotFoundException("Order not found");
        }
        return order;
    }

    public async Task<bool> DoesCustomerExist(int customerId)
    {
        return await _context.Customers.AnyAsync(e => e.Id == customerId);
    }

    public async Task<bool> DoesConcertExist(string concertName)
    {
        return await _context.Concerts.AnyAsync(e => e.Name == concertName);
    }

    public async Task<bool> DoesCustomerHasMoreThan5Tickets(int customerId)
    {
        return await _context.PurchasedTickets.CountAsync(e => e.CustomerId == customerId) > 5;
    }
}