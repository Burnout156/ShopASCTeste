using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopASCLibrary.Commands.Orders;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using ShopASCLibrary.Queries.OrderQueries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopASCLibrary.Handlers.Command.OrderCommands
{
    public class OrderCommandHandlers :
        IRequestHandler<CreateOrderCommand, int>,
        IRequestHandler<UpdateOrderCommand, Unit>,
        IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public OrderCommandHandlers(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                ShippingAddress = request.ShippingAddress,
                OrderDate = DateTime.Now, // Setar a data atual
                OrderProducts = request.OrderItems.ToList() // Converter a lista de produtos diretamente
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.OrderId);

            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            var productIds = request.OrderItems.Select(item => item.Id).ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            order.CustomerName = request.CustomerName;
            order.ShippingAddress = request.ShippingAddress;
            order.OrderProducts.Clear();
            order.OrderProducts.AddRange(products);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.OrderId);

            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
