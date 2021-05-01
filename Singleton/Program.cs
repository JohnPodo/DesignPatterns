using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Singleton
{
    //Monostate Pattern
    public class ChiefExecutiveOfficer
    {
        private static string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private static int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return String.Format($"Name : {name} , Age : {Age}");
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            var ceo = new ChiefExecutiveOfficer();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;
            var ceo2 = new ChiefExecutiveOfficer();
            Console.WriteLine(ceo2);
            Console.ReadKey();
        }
    }
}
