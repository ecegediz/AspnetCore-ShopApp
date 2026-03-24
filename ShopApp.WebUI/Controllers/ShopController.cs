using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
using System.Linq; // Bunu eklemezsen Select çalışmaz
using ShopApp.Entities; // Product ve Category sınıflarını tanıması için şart

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        // private ICategoryService _categoryService;
        public ShopController(IProductService productService /*,ICategoryService categoryService*/)
        {
            _productService = productService;
            // _categoryService = categoryService;
        }
        public IActionResult Details(int? id )
        {   if(id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductDetails((int)id);
            if (product == null)
            { 
               return NotFound();
            }

            return View(new ProductDetailsModel()
            {
                Product = product,
                // Eğer ProductCategories null ise boş bir liste oluştur, değilse kategorileri seç
                Categories = product.ProductCategories?.Select(i => i.Category).ToList() ?? new List<Category>()
            });
        }

        public IActionResult List(string category,int page=1)//page=1 varsayılan olarak 1. sayfayı gösterir ,paginasyon için page parametresi ekledik
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {   
                PageInfo = new PageInfo()
                { 
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                //Categories = _categoryService.GetAll()
            });
        }
    }
}
