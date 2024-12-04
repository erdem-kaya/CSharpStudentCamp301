
using System.Collections.Generic;

namespace CSharpStudentCamp301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        //Virtual keyword is used to create a virtual property in the entity class.
        public virtual Category Category { get; set; }
        //Order class is used to create a one-to-many relationship with the Product class.
        public List<Order> Orders { get; set; }

    }
}
