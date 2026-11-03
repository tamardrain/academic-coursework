namespace Medicine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicine[] medicine = new Medicine[6];
            medicine[0] = new Syrop();
            medicine[1] = new Medicine(new DateTime(2025, 12, 31));
            medicine[2] = new Medicine(new DateTime(2020, 01, 01));
            medicine[3] = new Medicine(new DateTime(1998, 11, 05));
            medicine[4] = new Syrop();
            medicine[5] = new Medicine(new DateTime(1987, 02, 17));
            //---------------------Printouts 
            Console.WriteLine(medicine[0].isGoodUsed(1)); //true went to the child's function and returned
            Console.WriteLine(medicine[1].isGoodUsed(1.5)); //false went to the parent's function and returned
            Console.WriteLine(medicine[4].isGoodAmount(260)); //in the child there is a condition and therefore returned false
            Console.WriteLine(medicine[5].isGoodAmount(260)); //in the parent there is no condition and therefore returned true
            //Caution when casting from parent to child
            //To prevent a compilation error, I must condition the execution of the following line
            if (medicine[1] is Syrop)
            {
                //If the medicine is allocated to a type of syrup, we will cast it to syrup and then we can execute a function from syrup
                Console.WriteLine(((Syrop)medicine[1]).isFoodColor());
            }
            Console.WriteLine(medicine[1].Chekced(medicine[0], medicine[4], 15)); 

        }
    }
}