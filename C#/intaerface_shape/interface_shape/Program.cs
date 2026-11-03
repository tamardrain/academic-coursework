namespace interface_shape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(4, 8,"red", TypeFrame.Part);
            r.print();

            //********
            //********
            //********
            //********
                      
            Shape s= new Circle(3,"black",TypeFrame.lines);
            I3Dable i1 = new Box(9,3,7,6,"green",TypeFrame.points);
            Rectangle r1= new Rectangle(3,6,"gray",TypeFrame.Part);
            I3Dable i2 = new Galilee(4, "pink", TypeFrame.lines);
            Console.WriteLine(BoxStorage.isPutInBox(i1,s));
            //true
            Console.WriteLine(BoxStorage.isPutInBox(i2,r1));
            //false
            Rectangle [] r3= new Rectangle[4];
            r3[0]=r1 ;
            r3[1] = (Box)i1;
            r3[2]= new Box(6, 4, 3, 2, "red", TypeFrame.lines);
            r3[3] = r;
            for (int i = 0; i < r3.Length; i++)
            {
                Console.Write(r3[i] + ",");
            }
            Console.WriteLine();
            Array.Sort(r3,(a,b) => a.GetPerimeter().CompareTo(b.GetPerimeter()));
            for (int i = 0; i < r3.Length; i++)
            {
                Console.Write(r3[i]+",");
            }
            Console.WriteLine();
            Circle [] c1= new Circle[4];
            c1[0] = (Circle)s;
            c1[1]= new Circle(5,"yellow",TypeFrame.lines);
            c1[2]=new Circle(6,"blue",TypeFrame.points);
            c1[3] = new Circle(8, "pink", TypeFrame.Part);
            for (int i = 0; i < c1.Length; i++)
            {
                Console.Write(c1[i] + ",");
            }
            Console.WriteLine("----------------------");
            Array.Sort(c1, (b, a) => a.GetPerimeter().CompareTo(b.GetPerimeter()));
            for (int i = 0; i < c1.Length; i++)
            {
                Console.Write(c1[i] + ",");

            }
        }
    }
}
