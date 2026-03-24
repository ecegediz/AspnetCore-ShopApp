using ShopApp.Entities;

namespace ShopApp.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }//Bu toplam ürün sayısını tutarız
        public int ItemsPerPage { get; set; }//Bu sayfa başına kaç ürün göstermek istediğimizi belirleriz
        public int CurrentPage { get; set; }//Bu sayfa numarasını tutarız
        public string CurrentCategory { get; set; }
        public int TotalPages() { 
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); 
        } //=> (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);//Bu sayfa sayısını hesaplarız veya
    }
    public class ProductListModel
    {
        public PageInfo PageInfo { get; set; } // İsim Controller ile aynı olsun
        public List<Product> Products { get; set; }
    }
}
