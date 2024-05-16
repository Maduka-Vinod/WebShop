using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;

        public List<Product> Products { get; set; } = new List<Product>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.ToList();
        }
    }
}
