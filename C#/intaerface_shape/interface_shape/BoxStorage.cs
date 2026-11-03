using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public static class BoxStorage
    {
        public static bool isPutInBox(I3Dable tool,Shape s)
        {
            if (tool is Circle && s is Circle)
                return ((Circle)s).Radius < ((Circle)tool).Radius;
            if (tool is Rectangle && s is Circle)
                return ((Circle)s).Radius < ((Rectangle)tool).Length && ((Circle)s).Radius <  ((Rectangle)tool).Width;
          
            return false;
        }
        // In storage boxes, write an additional function that receives a tool, shape, and quantity.
        // The function calls the previous function and checks if the tool can fit.
        // Additionally, it checks if there is sufficient space in terms of height
        // (the "fill height up to" property is still smaller than the tool's height).
        // If there is space, it inserts the shape into the tool
        // (meaning it updates the "up to..." property by adding 1 to it).
        public static bool isPutCountBox(I3Dable tool, Shape s, int count)
        {
            if (isPutInBox(tool, s) && tool.HeigthFull <= tool.Heigth)
            {
                tool.HeigthFull += 3;
                return true;
            }


            return false;
        }
        
    }
}
