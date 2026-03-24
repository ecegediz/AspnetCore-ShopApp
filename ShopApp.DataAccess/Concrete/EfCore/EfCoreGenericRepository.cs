using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T> where T : class where TContext : DbContext, new() //generic repository oluşturduk. T entity türünü temsil eder, TContext ise dbcontext türünü temsil eder. where T:class ile T'nin bir class olduğunu belirtiriz, where TContext:DbContext,new() ile TContext'in bir dbcontext olduğunu ve new() ile de newlenebilir olduğunu belirtiriz.
    {
        public void Create(T entity)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
               context.Set<T>().Add(entity); //context.Set<T>() ile T türünde bir DbSet'e erişiriz ve Add() metodu ile entity'yi ekleriz.
                context.SaveChanges(); //SaveChanges() metodu ile yapılan değişiklikleri veritabanına kaydederiz.
            }
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
                context.Set<T>().Remove(entity); //context.Set<T>() ile T türünde bir DbSet'e erişiriz ve Add() metodu ile entity'yi ekleriz.
                context.SaveChanges(); //SaveChanges() metodu ile yapılan değişiklikleri veritabanına kaydederiz.
            }
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
                return filter == null ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList(); //filter null ise tüm verileri döndürürüz, filter null değilse filter'ı uygularız.
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
                return context.Set<T>().Find(id); //context.Set<T>() ile T türünde bir DbSet'e erişiriz ve Find() metodu ile id'ye göre entity'yi buluruz.
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
               return context.Set<T>().Where(filter).SingleOrDefault(filter); //context.Set<T>() ile T türünde bir DbSet'e erişiriz ve SingleOrDefault() metodu ile filter'a göre tek bir entity döndürürüz. Eğer filter'a uyan birden fazla entity varsa hata verir, eğer hiç entity yoksa null döndürür.
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext()) //using bloğu ile context nesnesini oluştururuz. using bloğu, context nesnesinin işimiz bittiğinde otomatik olarak dispose edilmesini sağlar.
            {
                context.Entry(entity).State = EntityState.Modified; //context.Entry(entity) ile entity'nin durumunu alırız ve State'i Modified olarak ayarlarız. Bu, entity'nin güncelleneceğini belirtir.
                context.SaveChanges(); //SaveChanges() metodu ile yapılan değişiklikleri veritabanına kaydederiz.
            }
        }
    }
}
