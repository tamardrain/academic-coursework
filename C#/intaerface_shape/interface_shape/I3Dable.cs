using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_shape
{
    public  interface I3Dable
    {
        public int Heigth {  get; set; }
        public double SurfaceArea();
        public double Volume();
        public double HeigthFull { get; set; }

    }
}
