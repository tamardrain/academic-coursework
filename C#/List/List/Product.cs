using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public Product(string Name, int Price, string Color)
        {
            this.Name = Name;
            this.Price = Price;
            this.Color = Color;
        }
        public override string ToString() 
        {
            return "name: " + Name + "price: " + Price + "color: " + Color;
        }     
    }
}
