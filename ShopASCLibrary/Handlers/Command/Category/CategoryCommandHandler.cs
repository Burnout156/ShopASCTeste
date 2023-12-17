using MediatR;
using ShopASCLibrary.Commands.Category;
using ShopASCLibrary.Commands.CategoryCommand;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Handlers.Command.CategoryHandler
{
    public class CategoryCommandHandler :
    IRequestHandler<CreateCategoryCommand, int>,
    IRequestHandler<UpdateCategoryCommand, Unit>,
    IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public CategoryCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
                // Outras propriedades, se houver
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            category.Name = request.Name;
            // Atualize outras propriedades conforme necessário

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
