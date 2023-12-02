using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Data
{
    public class Drinks
    {
        [Key]
        public int drink_Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}

