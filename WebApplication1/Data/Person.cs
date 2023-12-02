namespace WebApplication1.Data { 
public class Person : Microsoft.AspNetCore.Identity.IdentityUser
{ 
    public Person() : base()
    {
        this.ListOrders = new HashSet<Orders>();

    }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string phone { get; set; }
        public int number_of_orders { get; set; }
        public virtual ICollection<Orders> ListOrders { get; set; }
    }
}

