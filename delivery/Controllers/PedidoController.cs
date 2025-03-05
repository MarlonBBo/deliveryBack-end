using delivery.Model;
using delivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace delivery.Controllers
{
    [ApiController]
    [Route("/")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoInterface _pedido;

        public PedidoController(IPedidoInterface pedido)
        {
            _pedido = pedido;
        }

        [HttpGet("Lista")]
        public async Task<List<Pedido>>Lista()
        {
            var pedido = await _pedido.ListPedidos();
            return pedido;
        }
    }
}
