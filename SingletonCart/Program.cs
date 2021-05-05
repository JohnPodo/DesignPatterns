using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonCart
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    sealed class CartSingleton
    {

        private static int counter = 0;
        private CartSingleton()
        {
            counter++;
            Console.WriteLine("Created a new one");
        }

        private static readonly CartSingleton _CartInstance = new CartSingleton();

        public static CartSingleton CartInstance
        {
            get
            {
                return _CartInstance;
            }

        }


    }
}
