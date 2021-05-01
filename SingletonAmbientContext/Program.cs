using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonAmbientContext
{
    class Program
    {
        public sealed class BuildingContext : IDisposable
        {
            public int WallHeight = 0;
            public int WallThickness = 300;
            private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

            static BuildingContext()
            {
                //ensure there is at least one state
                stack.Push(new BuildingContext(0));
            }

            public BuildingContext(int wallHeight)
            {
                WallHeight = wallHeight;
                stack.Push(this);
            }

            public static BuildingContext Current => stack.Peek();

            public void Dispose()
            {
                if (stack.Count > 1)
                    stack.Pop();
            }
        }

        public class Building
        {
            public readonly List<Wall> Walls = new List<Wall>();

            public override string ToString()
            {
                var sb = new StringBuilder();
                foreach(var wall in Walls)
                {
                    sb.AppendLine(wall.ToString());
                }
                return sb.ToString();
            }
        }

        public struct Point
        {
            private int X, Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
               
                return $"X : {X} , Y: {Y}";
            }
        }

        public class Wall
        {
            public Point Start, End;
            public int Height;
            public const int UseAmbient = Int32.MinValue;
            public Wall(Point start, Point end)
            {
                Start = start;
                End = end;
                Height = BuildingContext.Current.WallHeight;
            }

            public override string ToString()
            {

                return $"Start : {Start} , End: {End} , Height: {Height}";
            }
        }

        static void Main(string[] args)
        {
            var house = new Building();

            //ground floor
            using (new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 5000)));
            }
            //first floor
            using(new BuildingContext(3500))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 5000)));
            }

            Console.WriteLine(house);

            Console.ReadKey();
        }
    }
}
