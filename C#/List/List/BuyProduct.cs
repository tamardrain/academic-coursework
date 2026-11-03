using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class BuyProduct
    {
        public string NameOfProduct { get; set; }
        public int CountProducts { get; set; }
        public BuyProduct(string NameOfProduct, int CountProducts)

        {
            this.NameOfProduct=NameOfProduct;
            this.CountProducts=CountProducts;
        }

    }
}
