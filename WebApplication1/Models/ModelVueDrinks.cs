using System.Security.Policy;
using System.ComponentModel.DataAnnotations;

using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class ModelVueDrinks
    {
        [Key]
        public int drink_Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
