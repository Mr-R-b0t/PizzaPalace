using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class ModelVueCustomers
    {
        [Key]
        public int costumer_Id { get; set; }
        public string name { get; set; }
        public ICollection<Orders> ListOrders { get; set; }
        public int number_of_orders { get; set; }
        public string city { get; set; }
    }
}