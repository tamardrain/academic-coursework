using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garden
{
    public enum Types
    {
        idle,
        fruit
    }
    public enum LeafTypes
    {
        toothed,
        broad
    }
    internal class Tree:Plant
    {
        public Types Type { get; set; } 
        public LeafTypes LeafType { get; set; }
        public static int countTrees = 0;
        public Tree(Types Type, LeafTypes LeafType, string namePlant, GrowingSeasons growing, double countWater, DateTime plantingDate, bool isElk) : base(namePlant, growing, countWater, plantingDate, isElk)
        {
            this.Type = Type;
            this.LeafType = LeafType;
            if (countTrees<50)
            {
                countTrees++;
            }
            else
            {
                Console.WriteLine("The number of trees is too large");
            }

        }

        public override string ToString()
        {
            return $"NamePlant: {NamePlant}, Type: {Type}, LeafType: {LeafType}, Growing: {Growing}, CountWater: {CountWater}, PlantingDate: {PlantingDate.ToShortDateString()}, IsElk: {IsElk}";
        }
        public bool isOrla()
        {
            if ((DateTime.Now.Year)-(this.PlantingDate.Year)<3)
            {
                return true;  
            }
            return false;
        }
        static Tree()
        {
            Console.WriteLine("Congratulations on planting the first tree!");
        }
        public static bool IsGoodCountWater(out double counter, params Tree[] tree)
        {
            counter = 0;
            for (int i = 0; i < tree.Length; i++)
            {
                counter += tree[i].CountWater;

            }
            
            if (counter > 500) {
                return false; }
       return true;
        }
    }
}
