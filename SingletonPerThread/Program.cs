using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPerThread
{
    public sealed class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> threadInstance =
            new ThreadLocal<PerThreadSingleton>(() => new PerThreadSingleton());

        public int ID;

        private PerThreadSingleton()
        {
            ID = Thread.CurrentThread.ManagedThreadId;
        }

        public static PerThreadSingleton Instance => threadInstance.Value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => Console.WriteLine("t1:" + PerThreadSingleton.Instance.ID));
            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("t2:" + PerThreadSingleton.Instance.ID);
                Console.WriteLine("t2:" + PerThreadSingleton.Instance.ID);
            });
            Task.WaitAll(t1,t2);
            Console.ReadKey();
        }
    }
}
