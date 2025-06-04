namespace ExampleTest2.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string Status { get; set; } = null!;
    public ClientDto ClientDto { get; set; } = null!;
    public List<ProductDto> Products { get; set; } = null!;
}

public class ClientDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class ProductDto
{
    public string ProductName { get; set; } = null!;
    public double Price { get; set; }
    public int Amount { get; set; }
}