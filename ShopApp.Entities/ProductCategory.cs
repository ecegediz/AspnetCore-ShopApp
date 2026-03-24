using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }//2 taraftan gelen ıd bilgilerini birleştiriyoruz birleşim tablosu olarak kullanıyoruz 
       // public int Id { get; set; }
    }
}
