using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseInFilteringViaSpecification
{
    public class dummy
    {
        public string name;
        public int Age;

        public dummy(string name, int age)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
        }
    }

    public enum OrderBy
    {
        Name,Age
    }

    public interface ISpecification<T>
    {
        bool isSatisfied(T t);
    }

    public interface IOrderBy<T>
    {
        List<T> Filter(List<T> data, ISpecification<T> spec);
    }

    public class NameSpecification : ISpecification<dummy>
    {
        private OrderBy type;
        public NameSpecification(OrderBy type)
        {
            this.type = type;
        }
        public bool isSatisfied(dummy p)
        {
            return p.name == type;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<dummy> f2 = new List<dummy>()
            {
               new dummy("Sakis",2) ,
               new dummy("Makos",4) ,
               new dummy("Alexis",3) ,
               new dummy("Giannis",1) ,
               new dummy("Kwstas",6) ,
               new dummy("Kleanthis",7) ,
               new dummy("Eirini",9) 
                
            };


        }
    }
}
