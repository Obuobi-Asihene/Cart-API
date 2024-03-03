namespace CartAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Cart Cart { get; set; }
    }
}
