

namespace delivery.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Items> Items { get; set; }
    }
}