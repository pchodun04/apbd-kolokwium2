using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)] public string SerialNumber { get; set; } = null!;
    public int SeatNumber { get; set; }
    public ICollection<TicketConcert> TicketConcerts { get; set; } = null!;
}