namespace garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Plant p1 = new Plant();
            Console.WriteLine(p1.Id);
            Console.WriteLine(Plant.countPlant);
            Plant p2 = new Plant();
            Console.WriteLine(p2.Id);
            Console.WriteLine(Plant.countPlant);
            Flower f = new Flower(Colors.Red, "yasmin", GrowingSeasons.winter, 4.3, new DateTime(2026, 10, 12), true);
            Console.WriteLine(f.isToPlantNear(f));
            
             

        }
    }
}
