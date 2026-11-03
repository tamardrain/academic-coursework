using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    class Syrop : Medicine
    {
        public enum Taste { strawberry, orange, raspberry, fruit };

        public Syrop() : base(DateTime.Now.AddYears(3))
        {

        }
        public bool isFoodColor()
        {
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].Name.Contains("צבע מאכל")|| materials[i].Name.Contains("food color"))
                {
                    return true; 
                }
            }
            return false;
        }
        public override bool isGoodUsed(double age)
        {
            if (age>0.5&&age<12)
            {
              return true;  
            }
            return false;   
        }
        public override bool isGoodAmount(int sum)
        {

            if(sum<250)
                return true;
            return false;

        }

    }
}
