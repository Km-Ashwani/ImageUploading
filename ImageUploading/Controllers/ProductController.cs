using ImageUploading.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploading.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext _context;
        IWebHostEnvironment env;
        public ProductController(ProductDbContext context, IWebHostEnvironment env)
        {
            this._context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductModelView prod)
        {
            string filename="";
            if (prod.picture!=null)
            {
                var ext = Path.GetExtension(prod.picture.FileName);
                var size = prod.picture.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                {
                    if(size <= 1000000)
                    {
                        string folder = Path.Combine(env.WebRootPath, "images");
                        filename = $"{Guid.NewGuid().ToString()}_{prod.picture.FileName}";
                        string filepath = Path.Combine(folder, filename);
                        prod.picture.CopyTo(new FileStream(filepath, FileMode.Create));
                        Product p = new Product()
                        {
                            Name = prod.Name,
                            Price = prod.Price,
                            ImgPath = filename
                        };
                        _context.Products.Add(p);
                        _context.SaveChanges();
                        TempData["success"] = "product added...";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["sizeerror"] = "less than 1mb";
                    }
                }
                else
                {
                    TempData["exterror"] = "only jpg, png, jpeg picture allowed";
                }
            }
            return View();
        }

    }
}
