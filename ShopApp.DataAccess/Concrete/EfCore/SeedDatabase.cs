using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            //context.Database.Migrate();

            // Kontrolleri kaldırıp direkt ekliyoruz (Sadece bu seferlik)
            context.Categories.AddRange(Categories);
            context.Products.AddRange(Products);
            context.SaveChanges();

            context.ProductCategories.AddRange(ProductCategory);
            context.SaveChanges();
        }


        private static Category[] Categories =
                {
                    new Category(){Name="Telefon"},
                    new Category(){Name="Bilgisayar"},
                    new Category(){Name="Elektronik"},
                    new Category(){Name="Beyaz Eşya"},
                    new Category(){Name="Küçük Ev Aletleri"}
                };
                private static Product[] Products =
                {
                    new Product(){Name="Iphone 13",Price=15000,ImageUrl="1.jpeg", Description="<p>güzel telefon </p>"},
                    new Product(){Name="Iphone 14",Price=20000,ImageUrl="2.webp",  Description="<p>güzel telefon </p>"},
                    new Product(){Name="Iphone 15",Price=25000,ImageUrl="3.webp", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Samsung S22",Price=12000,ImageUrl="4.webp", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Samsung S23",Price=17000,ImageUrl="5.jpeg", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Samsung S24",Price=22000,ImageUrl="6.jpg", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Macbook Pro 2020",Price=20000,ImageUrl="7.webp", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Macbook Pro 2021",Price=25000,ImageUrl="8.jpeg", Description = "<p>güzel telefon </p>"},
                    new Product(){Name="Macbook Pro 2022",Price=30000,ImageUrl="9.webp", Description = "<p>güzel telefon </p>"}
                };
           private static ProductCategory[] ProductCategory =
                {
                    new ProductCategory(){Product= Products[0],Category= Categories[0]},
                    new ProductCategory(){Product= Products[0],Category= Categories[2]},
                    new ProductCategory(){Product= Products[1],Category= Categories[0]},
                    new ProductCategory(){Product= Products[1],Category= Categories[1]},
                    new ProductCategory(){Product= Products[2],Category= Categories[0]},
                    new ProductCategory(){Product= Products[2],Category= Categories[2]},
                    new ProductCategory(){Product= Products[3],Category= Categories[1]}
                };
    }
}
