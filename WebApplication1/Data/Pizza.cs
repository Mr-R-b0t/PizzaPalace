using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Data
{
    public class Pizza
    {
        [Key]
        public int pizza_Id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public decimal price { get; set; }
}

}
