using Shared.Mediator;

namespace Discount.Application.Commands;

public class DeleteDiscountCommand: IRequest<bool>
{
    public string ProductName { get; set; }

    public DeleteDiscountCommand(string productName)
    {
        ProductName = productName;
    }
}