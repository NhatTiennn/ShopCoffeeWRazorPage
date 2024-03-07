using BusinessObject.Models;

namespace CatCoffeePlatformWebRazorPage.BusinessObject.DTO
{
    public class BookingDto 
    {
        public int ShopId { get; set; }
        public string BookingDate { get; set; }
        public double Total { get; set; }
        public int AccountId { get; set; }
        public List<ListDrink> listDrinks { get; set; }
        public List<ListFood> listFoods { get; set; }
        public int TableId { get; set; }
        public int SlotId { get; set; }
    }

    public class ListDrink
    {
        public int drinkId { get; set; }
        public int quantity { get; set; }
        public double Price { get; set; }
        public ListDrink()
        {
            
        }
    }

    public class ListFood
    {
        public int foodId { get; set; }
        public int quantity { get; set; }
        public double Price { get; set; }
        public ListFood()
        {
            
        }
    }
}
