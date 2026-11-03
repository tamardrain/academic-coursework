using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
public enum TypeFrame
    {
        Part,
        points,
        lines
    }
    public abstract class Shape
    {
        public string Color { get; set; }
        public TypeFrame TypeFrame { get; set; }

        //Calculation of Area and Perimeter

        // public abstract double ScopeCalc();
        // public abstract double AreaCalc();
        //print
        public abstract void print();
        public override string ToString()
        {
            return "color: "+Color + "TypeFrame: "+ TypeFrame;
        }
        //c-tor
        public Shape(string Color, TypeFrame TypeFrame)
        {
            this.Color = Color;
            this.TypeFrame = TypeFrame;
        }



    }
}
