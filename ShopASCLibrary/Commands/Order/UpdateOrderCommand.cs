using MediatR;
using ShopASCLibrary.Models;

public class UpdateOrderCommand : IRequest<Unit>
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }

    public List<Product> OrderItems { get; set; }
}
