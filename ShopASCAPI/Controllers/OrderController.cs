using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopASCLibrary.Commands.Orders;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Models;
using ShopASCLibrary.Queries.OrderQueries;
using System.Threading.Tasks;

namespace ShopASCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            var orderId = await _mediator.Send(createOrderCommand);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderCommand updateOrderCommand)
        {
            if (id != updateOrderCommand.OrderId)
                return BadRequest("The provided ID does not match the command data.");

            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });

            order.CustomerName = updateOrderCommand.CustomerName;
            order.ShippingAddress = updateOrderCommand.ShippingAddress;

            // Atualiza a lista de produtos no pedido
            order.OrderProducts = updateOrderCommand.OrderItems.Select(item => new Product
            {
                Id = item.Id,
                // Se necessário, você pode adicionar mais propriedades aqui
            }).ToList();

            await _mediator.Send(updateOrderCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var deleteCommand = new DeleteOrderCommand(id);
                await _mediator.Send(deleteCommand);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
