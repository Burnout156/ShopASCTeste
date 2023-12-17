using MediatR;
using ShopASCLibrary.Models;

public class CreateOrderCommand : IRequest<int>
{
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }
        
    public List<Product> OrderItems { get; set; }
}
