using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Point
    {

        private double x, y;

        protected Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }


        //Factory Property
        public static Point Origin => new Point(0, 0);


        //Factory Method
       

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho,double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        public override string ToString()
        {
            return $"{x} {y}";
        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCartesianPoint(0, 2);
            var point1 = Point.Factory.NewPolarPoint(0, 2);
            Console.WriteLine(point1);
            Console.ReadKey();
        }
    }
}
