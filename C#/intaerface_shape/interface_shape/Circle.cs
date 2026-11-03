using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public class Circle:Shape, IPerimeter
    {
        public double Radius { get; set; }
        public Circle(double Radius, string Color, TypeFrame TypeFrame) : base(Color, TypeFrame)
        {
            this.Radius = Radius;
        }
        public override void print()
        {
            Console.WriteLine("אני עיגול באורך: "+Radius*2);
        }
        public double GetPerimeter()
        {
            return (Radius * Radius) * 3.14;
        }
    }
}
