using delivery.Model;

namespace delivery.Repository
{
    public interface IItemInterface
    {
        Task<Items> CreateItem(Items item);
        Task<List<Items>> ListItems();
    }
}
