namespace Orders.Application.Exceptions;

public class OrderNotFoundException(string name, object key) : ApplicationException($"Entity {name} - {key} not found.")
{
}