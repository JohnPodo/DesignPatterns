using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Point
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

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
                //businees for PolarPoint
                return null;
            }
        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCartesianPoint(0, 2);
            Console.WriteLine(point.x);
            Console.ReadKey();
        }
    }
}
