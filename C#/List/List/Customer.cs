using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Stack<BuyProduct> Stack { get; set; }= new Stack<BuyProduct>();
        public Customer(string FirstName, string LastName, string Phone, Stack<BuyProduct> Stack)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Phone = Phone;
            this.Stack = Stack;
        }
        public Customer()
        {
            
        }
        public Customer(string LastName,Stack<BuyProduct> Stack)
        {
           this.LastName=LastName;
            this.Stack=Stack;
        }
        public override string ToString()
        {
            if (Stack!=null&& Stack.Count > 0)
            {
                return "name: " + Stack.Peek().NameOfProduct + ", count: " + Stack.Peek().CountProducts.ToString();
            }
            else
            {
                return "empty";
            }
                 
        }


    }
}
