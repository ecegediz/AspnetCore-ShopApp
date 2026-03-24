using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;

public class ProductManager : IProductService
{
    private ShopApp.DataAccess.Abstract.IProductDal _productDal;

    public ProductManager(ShopApp.DataAccess.Abstract.IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Create(Product entity)
    {
        _productDal.Create(entity);
    }

    public void Delete(Product entity)
    {
        _productDal.Delete(entity);
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }

    public Product GetById(int id)
    {
        return _productDal.GetById(id);
    }

    public int GetCountByCategory(string category)
    {
        return _productDal.GetCountByCategory(category);
    }

    // Detay sayfası için gereken metot
    public Product GetProductDetails(int id)
    {
        return _productDal.GetProductDetails(id);
    }

    public List<Product> GetProductsByCategory(string category, int page,int pageSize)
    {
        return _productDal.GetProductsByCategory(category, page, pageSize);
    }

    public void Update(Product entity)
    {
        _productDal.Update(entity);
    }
}