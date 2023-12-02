using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }

        public DateTime order_time { get; set; }
        public OrderStatus orderStatus { get; set; }
        public decimal total_price { 
            get
            {
                decimal total = 0;
                foreach (var pizza in ListPizzas)
                {
                    total += pizza.price;
                }
                foreach (var drink in ListDrinks)
                {
                    total += drink.price;
                }
                return total;
            }
        }
        public virtual Customers Customer { get; set; }
        public virtual Clerks Clerk { get; set; }
        public virtual DeliveryPeople DeliveryPerson { get; set; }
        public virtual ICollection<Pizza> ListPizzas { get; set; }
        public virtual ICollection<Drinks> ListDrinks { get; set; }

    }

    public enum OrderStatus
    {
        Pending,
        InPreparation,
        Indelivery,
        Completed, 
        Cancelled
    }   
}
