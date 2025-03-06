using delivery.Model;

namespace delivery.Repository
{
    public interface IPedidoInterface
    {
        Task<Pedido> CreatePedido(Pedido pedido, List<int> itensId);
        Task<List<Pedido>> ListPedidos();
    }
}
