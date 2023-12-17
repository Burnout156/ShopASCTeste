using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Commands.Category
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int categoryId)
        {
            Id = categoryId;
        }
    }
}
