// Pedido
using ShopASCLibrary.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }

    public List<Product> OrderProducts { get; set; } = new List<Product>();
}
