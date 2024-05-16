using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand{ get; set; }
        public string Category { get; set; }

        [Precision(16,2)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
