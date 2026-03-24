using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

      //  public List<Product> Products { get; set; }//1den fazla ürün list ama biz iki taraftan da çok ilişki kurduğumuz için bu yaoı kullanmıyoruz 
      public List<ProductCategory> ProductCategories { get; set; }
    }
}
