using delivery.Infra;
using delivery.Model;
using Microsoft.EntityFrameworkCore;

namespace delivery.Repository
{
    public class PedidoRepository : IPedidoInterface
    {
        private readonly AppConnectionContext _connectionContext;

        public PedidoRepository(AppConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public Task<Pedido> Create(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pedido>> ListPedidos()
        {
            try
            {
                var list = await _connectionContext.Pedidos.ToListAsync();

                if(list.Count <= 0)
                {
                    throw new Exception("Lista vazia!");
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
