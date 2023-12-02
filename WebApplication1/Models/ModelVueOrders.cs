using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class ModelVueOrders
    {
        [Key]
        public int order_Id { get; set; }
        public DateTime order_time { get; set; }
        public OrderStatus status { get; set; }
        public virtual Customers costumer { get; set; }
        public virtual Clerks clerk { get; set; }
        public ICollection<Pizza> ListPizzas { get; set; }
        public ICollection<Drinks> ListDrinks { get; set; }
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
    public enum OrderStatus
    {
        Pending,
        InPreparation,
        Indelivery,
        Completed, 
        Cancelled
    }
    }
    }