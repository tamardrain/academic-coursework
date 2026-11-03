using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garden
{
    [Flags]
    public enum GrowingSeasons
    {
        None = 0,
        winter=1,
        summer=2,
        fall=4,
        spring=8,
        annual=16
    }
    internal class Plant
    {
        private readonly int id;
        public static int countPlant=0;
        public int Id { get { return id; } }
        public string NamePlant { get; set; }

        public GrowingSeasons Growing { get; set; }
        private double countWater;
        public double CountWater
        {
            get { return countWater; }
            set 
            {
                if (value > 5.5)
                {
                    Console.WriteLine("The quantity is too large");
                }
                else
                {
                    countWater = value;
                }
            }
        }
        private DateTime plantingDate;
        public DateTime PlantingDate
        {
            get { return plantingDate; }
            set 
            {
                if (value.Year > DateTime.Now.Year)
                {
                    plantingDate = value;
                }
                else
                {
                    Console.WriteLine("the date is err");
                }
            }
        }
        public bool IsElk { get; set; }

        public int CalculateAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - PlantingDate.Year;

            // אם לא עבר יום ההולדת של הצמח בשנה הנוכחית
            if (today < PlantingDate.AddYears(age))
            {
                age--;
            }
            return age;
        }
        public Plant()
        {
            countPlant++;
            id = countPlant;
            
        }
        public Plant( string namePlant, GrowingSeasons growing, double countWater, DateTime plantingDate, bool isElk)
        {
            
            NamePlant = namePlant;
            Growing = growing;
            CountWater = countWater;
            PlantingDate = plantingDate;
            IsElk = isElk;
        }
        public override string ToString()
        {
            return $"NamePlant: {NamePlant}, Growing: {Growing}, CountWater: {CountWater}, PlantingDate: {PlantingDate.ToShortDateString()}, IsElk: {IsElk}";
        }
        //1.	N  ומגדילה את כמות ההשקיה  של הצמח בN כתבי פונקציה המקבלת כפרמטר מספר
        //העמיסי לפונקציה זו פונקציה שמגדילה את הכמות ב-1.
        public void addWater(double n)
        {
            CountWater += n;
        }
        public void addWater()
        {
            CountWater ++;
        }
    }

}
