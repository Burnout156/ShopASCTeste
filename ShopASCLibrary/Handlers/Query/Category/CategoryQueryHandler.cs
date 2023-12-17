using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using ShopASCLibrary.Queries.CategoryQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Handlers.Query.CategoryHandler
{
    public class CategoryQueryHandler :
    IRequestHandler<GetAllCategoriesQuery, List<Category>>,
    IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ApplicationDbContext _context;

        public CategoryQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name
                    // Outras propriedades, se houver
                })
                .ToListAsync(cancellationToken);

            return categories;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Where(c => c.Id == request.Id)
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name
                    // Outras propriedades, se houver
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return category;
        }
    }

}
