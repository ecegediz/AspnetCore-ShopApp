using ShopApp.Entities;

namespace ShopApp.WebUI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }//bir ürünün birden fazla kategorisi olabilir bu yüzden list olarak tanımladık
    }
}
