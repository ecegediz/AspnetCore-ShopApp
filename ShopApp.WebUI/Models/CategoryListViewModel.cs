namespace ShopApp.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<ShopApp.Entities.Category> Categories { get; set; }
    }
}
