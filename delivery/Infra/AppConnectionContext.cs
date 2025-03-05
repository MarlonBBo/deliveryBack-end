using delivery.Model;
using Microsoft.EntityFrameworkCore;

namespace delivery.Infra
{
    public class AppConnectionContext : DbContext
    {

        public AppConnectionContext(DbContextOptions<AppConnectionContext> options) : base(options)
        {

        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Items> Items { get; set; }

    }
}
