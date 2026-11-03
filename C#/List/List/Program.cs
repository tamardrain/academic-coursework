using System.Threading.Channels;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            products.Add("חולצה", new Product("חולצה", 150, "red"));
            products.Add("חצאית", new Product("חצאית", 200, "blue"));
            products.Add("קשתות לשיער", new Product("קשתות לשיער", 15, "cream"));
            products.Add("כיפות", new Product("כיפות", 20, "black"));
            products.Add("נעליים", new Product("נעליים", 180, "pink"));

            //--------------------------
            Customer c = new Customer();
            Customer c1 = new Customer();
            Customer c2 = new Customer();
            Customer c3 = new Customer();
            Customer c4 = new Customer();
            Customer c5 = new Customer();
            //---------------------------
            c.Stack.Push(new BuyProduct("חולצה", 3));
            c1.Stack.Push(new BuyProduct("קשתות לשיער", 1));
            c3.Stack.Push(new BuyProduct("נעליים", 2));
            c5.Stack.Push(new BuyProduct("כיפות", 6));
            //---------------------------
            Queue<Customer> queue = new Queue<Customer>();
            List<Customer> list = new List<Customer>();
            list.Add(c);
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Stack.Count > 0 && list[i].Stack.Peek().CountProducts > 5)
                {
                    queue.Enqueue(list[i]);
                    list.RemoveAt(i); 

                }
            }
              
            
            list.ForEach(l => Console.WriteLine(l + ", "));

            list.Sort((x, y) =>
            {
                if (x.Stack.Count > 0 && y.Stack.Count > 0)
                {
                    return x.Stack.Peek().CountProducts.CompareTo(y.Stack.Peek().CountProducts);
                }
                else
                {
                    return -1;
                }

            });
            Console.WriteLine("---------------------");
            list.ForEach(l => Console.WriteLine(l + ", "));
            Console.WriteLine("---------------------");
            if (products.ContainsKey(queue.Peek().Stack.Peek().NameOfProduct))
            {
                Console.WriteLine("המחיר הוא: "+products[queue.Peek().Stack.Peek().NameOfProduct].Price * queue.Peek().Stack.Peek().CountProducts);
            }
            queue.Dequeue();
            for (int i = 0; i <list.Count; i++)
            {
                if (list[i].Stack.Count>0)
                {
                    if (products.ContainsKey(list[i].Stack.Peek().NameOfProduct))
                {
                    Console.WriteLine("המחיר הוא: " + products[list[i].Stack.Peek().NameOfProduct].Price * list[i].Stack.Peek().CountProducts);
                }
                }
                
            }
            list.Clear();
            


        }
    }
    
}
