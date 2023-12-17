using MediatR;
using ShopASCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Queries.OrderQueries
{
    public class GetAllOrdersQuery: IRequest<List<Order>>
    {
    }
}
