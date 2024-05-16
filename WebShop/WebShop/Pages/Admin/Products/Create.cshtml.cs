using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();
        


        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
            
        }

        public void OnGet()
        {
            
        }

        public string errorMessage="";
        public string successMessage="";

        public void OnPost() 
        { 
            if(ProductDto.ImageFile==null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "Image file is required");
                return;

            }
            if(!ModelState.IsValid)
            {
                errorMessage="Please fix the errors";
                return;
            }
            //Save the image file
            string newFileName = DateTime.Now.ToString("YYYYMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);

            string imgFullpath = environment.WebRootPath + "/img" + newFileName;
            using(var stream =System.IO.File.Create(imgFullpath))
            {
                ProductDto.ImageFile.CopyTo(stream);
            }
            //Save the product to the database

            Product product = new Product
            {
                Name = ProductDto.Name,
                Brand = ProductDto.Brand,
                Category = ProductDto.Category,
                Price = ProductDto.Price,
                Description = ProductDto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now
            };
            context.Products.Add(product);
            context.SaveChanges();


            //clear the form
            ProductDto.Name="";
            ProductDto.Brand="";
            ProductDto.Category="";
            ProductDto.Price=0;
            ProductDto.Description="";
            ProductDto.ImageFile=null;


            ModelState.Clear();
            successMessage="Product created successfully";

            Response.Redirect("/Admin/Products/Index");
        }

    }
}
