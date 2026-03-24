using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IOrderDal: IRepository<Order> //ayrı ayrı ıproduct vs oluşturduk çünkü her biri farklı işlemler için kullanılabilir. örneğin ıorderdal da siparişle ilgili işlemler yapacağız. o yüzden ayrı ayrı oluşturduk.
    {
    }
}
