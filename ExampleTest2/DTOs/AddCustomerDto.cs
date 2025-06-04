using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.DTOs;

public class AddCustomerDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    public List<TicketPurchaseDto> TicketPurchases { get; set; }
}

public class TicketPurchaseDto
{
    [Required]
    public int SeatNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string ConcertName { get; set; }
    [Required]
    [Precision(10,2)]
    public double Price { get; set; }
}