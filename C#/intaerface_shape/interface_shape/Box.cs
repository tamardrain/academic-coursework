using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public class Box:Rectangle,I3Dable, IPerimeter
    {
        
        public int Heigth {  get; set; }
        // Surface Area – (Base Area + Height * Width + Height * Length) * 2
        // Volume – Base * Height

        public double SurfaceArea()
        {
            return (Width * Length + Heigth * Width + Heigth * Length)*2;
        }
        public double Volume()
        {
            return (Width * Length) * Heigth;
        }
        public double HeigthFull { get; set; }
        public Box(int Heigth, double HeigthFull, int Width, int Length,string Color, TypeFrame TypeFrame) :base(Width, Length,Color,TypeFrame) 
        {
           this.Heigth = Heigth;
           this.HeigthFull= HeigthFull; 
        }
        public double GetPerimeter()
        {
            return 2 * (Width + Length);
        }

    }
}
