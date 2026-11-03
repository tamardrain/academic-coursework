using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public class Rectangle:Shape,IPerimeter
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public override void print()
        {
            for (int i = 0; i < this.Length; i++)
            {
                for (global::System.Int32 j = 0; j < this.Width; j++)
                {
                    Console.Write("*"); 
                }
                Console.WriteLine();
            }
        }
        public Rectangle(int Length, int Width,string Color, TypeFrame TypeFrame ) :base(Color,TypeFrame)
        {
            this.Length = Length;
            this.Width = Width;
        }
        public double GetPerimeter()
        {
            return 2 * (Width + Length);
        }
    }
}
