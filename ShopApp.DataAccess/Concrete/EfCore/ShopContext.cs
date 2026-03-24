using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class ShopContext: DbContext //HANGİ DATABASE KULLANACAĞIMIZI BELİRTİRİZ
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShopAppDb;Trusted_Connection=True;");//veritabanı bağlantısı yaparız
            optionsBuilder.EnableSensitiveDataLogging();
        }//shopcontext sınıfı dbcontext sınıfından kalıtım alır ve onconfiguring metodunu override ederiz ve burada veritabanı bağlantısını yaparız

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ara tabloyu SQL'deki gibi "ProductCategory" (tekil) yapıyoruz
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory"); // SQL'de gördüğüm isim bu
                entity.HasKey(pc => new { pc.CategoryId, pc.ProductId });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products"); // SQL'de gördüğüm isim bu
                entity.Property(e => e.Id).HasColumnName("Id");
            });

        // PRODUCT TABLO AYARI (Burası Id hatasını bitiren yer)
        modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "dbo"); // Şemayı (dbo) özellikle belirttik
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; } // BU SATIRI EKLE
    }
}
