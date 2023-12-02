using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ModelVuePizza
    {
        [Key]
        public int pizza_Id { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
