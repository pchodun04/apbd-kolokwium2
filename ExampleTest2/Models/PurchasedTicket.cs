using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Purchased_Ticket")]
[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]

public class PurchasedTicket
{
    [ForeignKey(nameof(TicketConcert))]
    public int TicketConcertId { get; set; }
    
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    
    public DateTime PurchaseDate { get; set; }

    public Customer Customer { get; set; } = null!;
    public TicketConcert TicketConcert { get; set; } = null!;

}