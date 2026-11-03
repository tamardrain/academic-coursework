using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    class Medicine
    {
        // Medicine class – (name, quantity, date, array of materials)
        public string Name { get; set; }
        private int sum;

        public int Sum
        {
            get { return sum; }
            set 
            {
                if (isGoodAmount(sum))
                {
                   sum = value; 
                }
                 

            }
        }

        public DateTime expirationDate { get; set; }
        public Material[] materials { get; set; }
        [Flags]
        public enum Problems { headache = 1, strepThroat = 2, earInfection = 4, backPain = 8 };

        public Medicine(DateTime date)
        {
            this.expirationDate = date;
        }

        public override string ToString()
        {
            return "name:" + Name + "sum:" + Sum + "expirationDate" + expirationDate + "materials" + materials;
        }
        public virtual bool isGoodUsed(double age)
        {
            if(age>2)
                return true;
            return false;
        }
        public virtual bool isGoodAmount(int sum)
        {
            
            return true;
         
        }

        public Medicine Chekced(Medicine m1,Medicine m2,double age)
        {
            if (age<12)
            {
                if (m1 is Syrop && m2 is not Syrop)
                {
                    return m1; 
                }
                if (m2 is Syrop && m1 is not Syrop)
                {
                    return m2;
                }
            }
            if (m1.materials.Length<m2.materials.Length)
            {
                return m1;
            }
            return m2;
        }




    }
}
