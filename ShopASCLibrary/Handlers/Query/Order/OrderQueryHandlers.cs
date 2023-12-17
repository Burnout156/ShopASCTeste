using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Models;
using ShopASCLibrary.Queries.OrderQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopASCLibrary.Handlers.Query.OrderQuery
{
    public class OrderQueryHandlers :
        IRequestHandler<GetAllOrdersQuery, List<Order>>,
        IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryHandlers(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        }
    }
}
