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


    class Program
    {
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
            //Console.ReadKey();
            #endregion
        }
    }
}
