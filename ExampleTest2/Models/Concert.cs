using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Concert")]
public class Concert
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int AvaiableTickets { get; set; }
    public ICollection<TicketConcert> TicketConcerts { get; set; } = null!;
}