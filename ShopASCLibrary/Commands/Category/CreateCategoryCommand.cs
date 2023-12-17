using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Commands.CategoryCommand
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Se necessário, você pode adicionar mais propriedades aqui para
        // representar dados associados à criação de uma categoria.
    }
}
