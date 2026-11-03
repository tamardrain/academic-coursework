using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public class Galilee:Circle,I3Dable
    {
        public Galilee(double Radius, string Color, TypeFrame TypeFrame) : base(Radius,Color, TypeFrame)
        {
            
        }
        public int Heigth { get; set; }
        public double SurfaceArea()
        {
            return Heigth * (Radius * 3.14 * 2);
        }


        public double Volume()
        {
            return Heigth * ((Radius * Radius )*3.14);
        }
        public double HeigthFull { get; set; }
    }
}
