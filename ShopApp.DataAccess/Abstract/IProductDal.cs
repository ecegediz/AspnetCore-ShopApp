using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ShopApp.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        // Detay sayfası için id alan tek bir metot yeterli
        Product GetProductDetails(int id);

        IEnumerable<Product> GetPopularProducts();
        int GetCountByCategory(string category);

        // Alttaki parametresiz metodu siliyoruz, çünkü id olmadan detay çekemezsin
        // Product GetProductDetails(); 
    }
}