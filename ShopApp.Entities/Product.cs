using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("Id")] // "Zorla bu ismi kullan" diyoruz
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        // Soru işareti (?) bu alanın NULL gelebileceğini belirtir
        public string? Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}