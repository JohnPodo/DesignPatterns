using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    #region Creation Builder
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;
        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImple(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }
            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImple(indent + 1));
            }
            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();

        }
        public override string ToString()
        {
            return ToStringImple(0);
        }
    }

    class HtmlBuilder
    {
        private readonly string rootName;
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        //not Fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        HtmlElement root = new HtmlElement();
    }

    #endregion
    class Program
    {

        static void Main(string[] args)
        {
            #region Creation Builder
            //Simple HTML Paragraph using StringBuilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);
            Console.WriteLine();
            //Html List With 2 words
            var words = new[] { "Hello", "World" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.Append($"<li>{word}</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
            Console.WriteLine();
            //ordinary non fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            //fluent builder
            sb.Clear();
            builder.Clear();
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            Console.WriteLine(builder);
            #endregion

            Console.ReadKey();
        }
    }
}
