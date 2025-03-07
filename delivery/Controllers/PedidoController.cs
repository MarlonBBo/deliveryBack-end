using delivery.DTO;
using delivery.Model;
using delivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace delivery.Controllers
{
    [ApiController]
    [Route("/pedido")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoInterface _pedido;

        public PedidoController(IPedidoInterface pedido)
        {
            _pedido = pedido;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            var pedido = await _pedido.ListPedidos();
            return Ok(
                    pedido.Select(pedido => new
                    {
                        pedido.Id,
                        pedido.Name,
                        pedido.Date,
                        Items = pedido.Items?.Select(item => new
                        {
                            item.Name,
                            item.Quantidade
                        }).ToList()
                    }).ToList()
                    );
        }


        [HttpPost("CreatePedido")]
        public async Task<IActionResult> CreatePedido([FromBody] PedidoDTO pedidoDto)
        {
            try
            {
                var pedido = new Pedido
                {
                    Name = pedidoDto.Name
                };

                var createdPedido = await _pedido.CreatePedido(pedido, pedidoDto.ItemIds);

                return Ok(new
                {
                    createdPedido.Id,
                    createdPedido.Name,
                    createdPedido.Date,
                    Items = createdPedido.Items.Select(item => new
                    {
                        item.Id,
                        item.Name,
                        item.Quantidade
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
