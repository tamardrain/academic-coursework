using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garden
{
    public enum MaintenanceFrequency
    {
        OnceAnHour,
        OnceADay,
        OnceAWeek
    }

    sealed internal class GreenhouseFlower:Flower
    {
        public string GreenhouseName { get; set; }
        public int RowNumber { get; set; }
        public int PotNumber { get; set; }
        public MaintenanceFrequency Frequency { get; set; }
        public GreenhouseFlower(MaintenanceFrequency Frequency, int PotNumber, int RowNumber, string GreenhouseName, Colors Color, string namePlant, GrowingSeasons growing, double countWater, DateTime plantingDate, bool isElk) : base(Color, namePlant, growing, countWater, plantingDate, isElk)
        {
            {
                this.Frequency = Frequency;
                this.PotNumber = PotNumber;
                this.RowNumber = RowNumber;
                this.GreenhouseName = GreenhouseName;
            }
        }
               public override string ToString()
        {
            return $"GreenhouseName: {GreenhouseName}, Frequency: {Frequency}, PotNumber: {PotNumber}, RowNumber: {RowNumber}, NamePlant: {NamePlant}, Color: {Color}, Growing: {Growing}, CountWater: {CountWater}, PlantingDate: {PlantingDate.ToShortDateString()}, IsElk: {IsElk}";
        }
        public override bool isToPlantNear(Flower f)
        {
            if (f is GreenhouseFlower&&this is GreenhouseFlower)
            {
                if (this.Growing == f.Growing && this.CountWater == f.CountWater&& ((GreenhouseFlower)f).Frequency== this.Frequency)
                    {  
                         return true;
                    }
           
            }
            return false;
        }
    }
   
}
