using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IRepository<T> //İNTERFACELERİ  aynı jenerik yapıda oluşturduk çünkü her entity için ayrı ayrı oluşturmak yerine tek bir interface ile tüm entityler için kullanabiliriz. örneğin ıproductdal, ıcategorydal, ıorderdal gibi ayrı ayrı interface oluşturmak yerine tek bir repository interface oluşturduk ve tüm entityler için kullanabiliriz. böylece kod tekrarını önlemiş oluruz.
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        void Create(T entity);
        void Update(T entity);

        void Delete(T entity);
    }
}
