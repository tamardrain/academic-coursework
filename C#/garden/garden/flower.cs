using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garden
{
    public enum Colors
    {
        Red,
        Green,
        Blue,
        yellow
    }
    internal class Flower:Plant
    {
        public Colors Color { get; set; }
        public Flower(Colors Color,string namePlant, GrowingSeasons growing, double countWater, DateTime plantingDate, bool isElk) :base(namePlant,growing,countWater,plantingDate,isElk)
        {
            this.Color = Color;
        }
        public override string ToString()
        {
            return $"NamePlant: {NamePlant}, Color: {Color}, Growing: {Growing}, CountWater: {CountWater}, PlantingDate: {PlantingDate.ToShortDateString()}, IsElk: {IsElk}";
        }
        public virtual bool isToPlantNear(Flower f)
        {
            if(this.Growing == f.Growing && this.CountWater==f.CountWater)
            {
                return true ;
            }
            return false ;
            
        }
        public static bool isToPlantNear(Flower f1, Flower f2)
        {
            if (f1.Growing == f2.Growing && f1.CountWater == f2.CountWater)
            {
                return true; 
            }
            return false ;
        }
        static Flower()
        {
            Console.WriteLine("Congratulations on planting the first flower!");
        }

    }
}
