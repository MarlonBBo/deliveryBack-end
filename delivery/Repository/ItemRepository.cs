using delivery.Infra;
using delivery.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace delivery.Repository
{
    public class ItemRepository : IItemInterface
    {
        private readonly AppConnectionContext _connectionContext;

        public ItemRepository(AppConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<Items> CreateItem(Items item)
        {
            try
            {
                var createItem = new Items()
                {
                    Name = item.Name,
                    Quantidade = item.Quantidade,
                };

                _connectionContext.Add(createItem);
                await _connectionContext.SaveChangesAsync();

                return createItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Items>> ListItems()
        {
            try
            {
                var list = await _connectionContext.Items.ToListAsync();

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
