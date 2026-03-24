using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Category>//metodların hepsi repository de var o yüzden sadece repository den kalıtım aldık ve o metotları kullanacağız
    {
        
    }
}
