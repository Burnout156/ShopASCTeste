using MediatR;
using ShopASCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Queries.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
