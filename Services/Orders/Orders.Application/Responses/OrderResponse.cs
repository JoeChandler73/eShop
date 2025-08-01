namespace Orders.Application.Responses;

public record OrderResponse
{
    public required int Id { get; init; }
    
    public required string UserName { get; init; }
    
    public required decimal TotalPrice { get; init; }

    public required string FirstName { get; init; }
    
    public required string LastName { get; init; }
    
    public required string EmailAddress { get; init; }
    
    public required string AddressLine { get; init; }
    
    public required string Country { get; init; }
    
    public required string State { get; init; }
    
    public required string ZipCode { get; init; }

    public required string CardName { get; init; }
    
    public required string CardNumber { get; init; }
    
    public required string Expiration { get; init; }
    
    public required string Cvv { get; init; }
    
    public required int PaymentMethod { get; init; }
}