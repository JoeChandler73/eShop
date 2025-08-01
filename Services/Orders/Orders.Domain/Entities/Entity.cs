namespace Orders.Domain.Entities;

public record Entity
{
    public int? Id { get; init; }
    
    public string? CreatedBy { get; set; }
    
    public DateTime? CreatedDate { get; set; }
    
    public string? LastModifiedBy { get; set; }
    
    public DateTime? LastModifiedDate { get; set; }
}