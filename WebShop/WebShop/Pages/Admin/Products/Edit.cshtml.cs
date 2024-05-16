using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();
        public Product Products { get; set; } = new Product();

        public string errorMessage = "";
        public string successMessage = "";
      
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            var Products = context.Products.Find(id);
            if(Products == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            ProductDto.Name = Products.Name;
            ProductDto.Brand = Products.Brand;
            ProductDto.Category = Products.Category;
            ProductDto.Price = Products.Price;
            ProductDto.Description = Products.Description;

            Products = Products;
        }
        
    }
}
