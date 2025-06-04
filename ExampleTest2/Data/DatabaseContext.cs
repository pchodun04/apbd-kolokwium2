using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DbSet<Concert> Concerts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123456789" },
            new Customer() { Id = 2, FirstName = "Jane", LastName = "Doe", PhoneNumber = "123456789"},
            new Customer() { Id = 3, FirstName = "Julie", LastName = "Doe", PhoneNumber = "987654321" },
        });

        modelBuilder.Entity<Concert>().HasData(new List<Concert>()
        {
            new  Concert(){Id = 1, Name = "Concert 1", Date = DateTime.Parse("2025-05-01"), AvaiableTickets = 100},
            new  Concert(){Id = 2, Name = "Concert 2", Date = DateTime.Parse("2025-05-02"), AvaiableTickets = 200}, 
            new  Concert(){Id = 3, Name = "Concert 3", Date = DateTime.Parse("2025-05-03"), AvaiableTickets = 300},
        });

        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>()
        {
            new PurchasedTicket(){TicketConcertId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-05-04")},
            new PurchasedTicket(){TicketConcertId = 2, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-05-05")},
            new PurchasedTicket(){TicketConcertId = 3, CustomerId = 3, PurchaseDate = DateTime.Parse("2025-05-06")}
        });
        
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket() { Id = 1, SerialNumber = "TK2034/S4531/12", SeatNumber = 1},
            new Ticket() { Id = 2, SerialNumber = "TK2027/S4831/133", SeatNumber = 2},
            new Ticket() { Id = 3, SerialNumber = "TK2032/S4121/139", SeatNumber = 3},
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>()
        {
            new TicketConcert() { Id = 1, TicketId = 1, ConcertId = 1, Price = 100.00},
            new TicketConcert() { Id = 2, TicketId = 2, ConcertId = 2, Price = 150.00},
            new TicketConcert() { Id = 3, TicketId = 3, ConcertId = 3, Price = 200.00}
        });
    }
}