using delivery.Model;

namespace delivery.Repository
{
    public interface IPedidoInterface //10120
    {
        Task<Pedido> Create(Pedido pedido);
        Task<List<Pedido>> ListPedidos();
    }
}
