using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
       // private ICategoryService _categoryService;
        public HomeController(IProductService productService /*,ICategoryService categoryService*/)
        {
            _productService = productService;
           // _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll(); // Ürünleri servisten çek
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
                //Categories = _categoryService.GetAll()
            });
        }
    }
}
