using delivery.DTO;
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

        public async Task<Pedido> CreatePedido(Pedido pedido, List<int> itensId)
        {
           
            try
            {
                var findItems = await _connectionContext.Items.Where(i => itensId.Contains(i.Id)).ToListAsync();

                if (findItems == null || findItems.Count == 0)
                {
                    throw new Exception("Item não encontrado");
                }

                var createPedido = new Pedido()
                {
                    Name = pedido.Name,
                    Date = DateTime.UtcNow,
                    Items = findItems
                };

                _connectionContext.Add(createPedido);
                await _connectionContext.SaveChangesAsync();

                return createPedido;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o pedido: " + ex.Message);
            }
        }

        public async Task<List<Pedido>> ListPedidos()
        {
            try
            {
                var list = await _connectionContext.Pedidos
                .Include(p => p.Items) 
                .ToListAsync();

                if (list.Count <= 0)
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
