using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saxon.Api;

namespace SaxonStaticParamXsltTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var processor = new Processor();

            var xsltCompiler = processor.NewXsltCompiler();

            var xsltExecutable1 = xsltCompiler.Compile(new Uri(Path.Combine(Environment.CurrentDirectory, "evaluate-example1.xsl")));

            var xslt30Transformer = xsltExecutable1.Load30();

            using (var inputStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "sample1.xml")))
            {
                xslt30Transformer.Transform(inputStream, processor.NewSerializer(Console.Out));
            }

            Console.WriteLine();

            xsltCompiler.SetParameter(new QName("xpath"), new XdmAtomicValue("xs:dateTime(//header/creationdate)"));

            var xsltExecutable2 = xsltCompiler.Compile(new Uri(Path.Combine(Environment.CurrentDirectory, "evaluate-example1.xsl")));

            xslt30Transformer = xsltExecutable1.Load30();

            using (var inputStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "sample1.xml")))
            {
                xslt30Transformer.Transform(inputStream, processor.NewSerializer(Console.Out));
            }

            Console.WriteLine();
        }
    }
}
