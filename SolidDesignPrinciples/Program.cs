using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDesignPrinciples
{
    #region Single Responsibility Classes
    //public class Journal //Mia Klassi pou Kanei Crud
    //{
    //    private readonly List<string> entries = new List<string>();
    //    private static int count = 0;
    //    public int AddEntry(string text)
    //    {
    //        entries.Add($"{++count}:{text}");
    //        return count;
    //    }

    //    public void RemoveEntry(int index)
    //    {
    //        entries.RemoveAt(index);
    //    }

    //    public override string ToString()
    //    {
    //        return string.Join(Environment.NewLine,entries);
    //    }
    //}

    //public class Persistence  // Mia klassi gia na pernei ta dedomena kai na ta emfanizei kai na ta diaxeirizetai
    //{
    //    public void SaveToFile(Journal j, string fileName, bool overwrite = false)
    //    {
    //        if (overwrite || !File.Exists(fileName))
    //        {
    //            File.WriteAllText(fileName, j.ToString());
    //        }
    //    }
    //}

    #endregion

    #region Open-Close Principle Methods-Classes
    //public enum Color
    //{
    //    Red,Green,Blue
    //}

    //public enum Size
    //{
    //    Small,Medium,Huge
    //}

    //public class Product
    //{
    //    public string Name;
    //    public Color color;
    //    public Size size;

    //    public Product(string name, Color color, Size size)
    //    {
    //        if (name == null)
    //        {
    //            throw new ArgumentNullException(paramName: nameof(name));
    //        }
    //        Name = name;
    //        this.color = color;
    //        this.size = size;
    //    }
    //}

    //public class ProductFiter
    //{
    //    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products,Size size)
    //    {
    //        foreach (var item in products)
    //        {
    //            if (item.size==size)
    //            {
    //                yield return item;
    //            }
    //        }
    //    }

    //    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color size)
    //    {
    //        foreach (var item in products)
    //        {
    //            if (item.color == size)
    //            {
    //                yield return item;
    //            }
    //        }
    //    }

    //    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Color color, Size size)
    //    {
    //        foreach (var item in products)
    //        {
    //            if (item.color == color&& item.size == size)
    //            {
    //                yield return item;
    //            }
    //        }
    //    }
    //}

    //public interface ISpecification<T>
    //{
    //    bool isSatisfied(Product p);
    //}

    //public interface IFilter<T>
    //{
    //    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    //}

    //public class ColorSpecification : ISpecification<Product>
    //{
    //    private Color _color;
    //    public ColorSpecification(Color color)
    //    {
    //        this._color = color;
    //    }
    //    public bool isSatisfied(Product p)
    //    {
    //        return p.color == _color;
    //    }
    //}

    //public class SizeSpecification : ISpecification<Product>
    //{
    //    private Size _size;
    //    public SizeSpecification(Size size)
    //    {
    //        this._size = size;
    //    }
    //    public bool isSatisfied(Product p)
    //    {
    //        return p.size == _size;
    //    }
    //}


    //public class AndSpecification<T> : ISpecification<T>
    //{
    //    private ISpecification<T> first,second;
    //    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    //    {
    //        this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
    //        this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
    //    }
    //    public bool isSatisfied(Product p)
    //    {
    //        return first.isSatisfied(p)&& second.isSatisfied(p);
    //    }
    //}


    //public class BetterFilter : IFilter<Product>
    //{
    //    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    //    {
    //        foreach(var i in items)
    //        {
    //            if (spec.isSatisfied(i))
    //            {
    //                yield return i;
    //            }
    //        }
    //    }
    //}

    #endregion

    #region LiskovSubstitutuinPrincipleClasses
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle()
        {

        }

        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public override string ToString()
        {
            return $"{nameof(Width)} : {Width} ,{nameof(Height)} : {Height} ";
        }
    }

    public class Square : Rectangle
    {
        public override int Width { set => base.Width = base.Height = value; }
        public override int Height { set => base.Width = base.Height = value; }
    }
    #endregion

    #region InterfaceSegregationPrinciple
    public class Document
    {
        public int number { get; set; }
    }
    // Chain me up in that way
    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    //Create The Machine
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    /// Free way
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {

        }
    }

    public class Photocopier : IScanner, IPrinter
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {

        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }

    public struct MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer is null)
            {
                throw new NotImplementedException();
            }
            if (scanner is null)
            {
                throw new NotImplementedException();
            }
            this.printer = printer;
            this.scanner = scanner;
        }
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
    #endregion

    #region DependencyInversionPrinciple

    //hl modules shoud not depend on low-level; both should depend on abstractions
    //abstractions should not depend on details; details should depend on abstractions
    public enum Relationship
    {
        Parent, Sibling, Child
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationShipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationShipBrowser //Low Level
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(s => s.Item1.Name == name && s.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    public class Research
    {
        public Research(Relationships relationships)
        {
            //high-level: find all of x's children
            //var relations=relationships.Relations;
            //foreach(var r in relations.Where(s=>s.Item1.Name=="x" && s.Item2 == Relationship.Parent)){
            //Console.WriteLine($"X has a child called {r.Item3.Name}");}
        }

        public Research(IRelationShipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }
    }
    #endregion
    public class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            #region Single Responsibility
            //var j = new Journal();
            //j.AddEntry("I Cried Today");
            //j.AddEntry("I Ate Today");
            //Console.WriteLine(j);

            //var p = new Persistence();
            //var filename = @"C:\Users\Podo\Desktop\journal.txt";
            //p.SaveToFile(j, filename,true);
            //Process.Start(filename);
            //Console.ReadKey();
            #endregion

            #region Open-Close Principle
            ////before
            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Medium);
            //var house = new Product("House", Color.Blue, Size.Huge);

            //Product[] products = { apple, tree, house };

            //var pf = new ProductFiter();
            //Console.WriteLine("Green Products (Old):");
            //foreach (var p in pf.FilterByColor(products, Color.Green)){
            //    Console.WriteLine($"- {p.Name} is green");
            //}


            ////after
            //var bf = new BetterFilter();
            //Console.WriteLine("Green products (New):");
            //foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            //{
            //    Console.WriteLine($"- {p.Name} is green");
            //}

            //Console.WriteLine("Big products (New):");
            //foreach (var p in bf.Filter(products, new SizeSpecification(Size.Huge)))
            //{
            //    Console.WriteLine($"- {p.Name} is Big");
            //}

            //Console.WriteLine("Big and Blue products (New):");
            //foreach (var p in bf.Filter(products,new AndSpecification<Product>( new SizeSpecification(Size.Huge),new ColorSpecification(Color.Blue))))
            //{
            //    Console.WriteLine($"- {p.Name} is Big and Blue");
            //}

            #endregion

            #region LiskovSubstitutuinPrinciple
            //Rectangle rc = new Rectangle(2, 3);
            //Console.WriteLine($"{rc} has Area {Area(rc)}");

            ///*This is Square*/
            //Rectangle sq = new Square();

            //sq.Width = 4;
            //Console.WriteLine($"{sq} has Area {Area(sq)}");
            #endregion

            #region DependencyInversionPrinciple
            var parent = new Person() {Name="John" };
            var child1 = new Person() {Name="Chris" };
            var child2 = new Person() {Name="Matt" };


            //low level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
            #endregion
            Console.ReadKey();
        }
    }
}
