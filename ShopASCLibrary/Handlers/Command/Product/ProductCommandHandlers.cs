using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopASCLibrary.Commands.Products;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using System.Threading;
using System.Threading.Tasks;

public class ProductCommandHandlers :
    IRequestHandler<CreateProductCommand, int>,
    IRequestHandler<UpdateProductCommand, Unit>,
    IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly ApplicationDbContext _context;

    public ProductCommandHandlers(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Crie um novo produto
        Product product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        // Obtenha a categoria do banco de dados usando o ID fornecido
        Category category = await _context.Categories.FindAsync(request.CategoryId);

        // Verifique se a categoria foi encontrada
        if (category == null)
        {
            // Lida com a lógica de erro se a categoria não for encontrada
            // Por exemplo, você pode lançar uma exceção informando que a categoria não foi encontrada.
            throw new NotFoundException(nameof(Category), request.CategoryId);
        }

        // Associe a categoria ao produto
        product.Category = category;

        // Adicione o produto ao contexto e salve as alterações
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        // Retorne o Id do produto após a inserção bem-sucedida
        return product.Id;

    }



    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);

        if (product == null)
            throw new NotFoundException(nameof(Product), request.Id);

        product.Name = request.Name;
        product.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);

        if (product == null)
            throw new NotFoundException(nameof(Product), request.Id);

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
