using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using ShopASCLibrary.Queries.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Handlers.Query.ProductQuery
{
    // ProductQueryHandlers.cs
    public class ProductQueryHandlers :
        IRequestHandler<GetProductQuery, Product>,
        IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryHandlers(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Include(p => p.Category)  // Inclui as informações da categoria
                .ToListAsync(cancellationToken);

            return products;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            return product;
        }

    }

}
