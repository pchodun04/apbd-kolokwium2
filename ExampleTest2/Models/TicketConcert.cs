using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Ticket_Concert")]
public class TicketConcert
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }
    [ForeignKey(nameof(Concert))]
    public int ConcertId { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(10,2)]
    public double Price { get; set; }
    
    public Concert Concert { get; set; } = null!;
    public Ticket Ticket { get; set; } = null!;
}