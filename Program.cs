using System;
using System.IO;

namespace codeparser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write the "flagfile" when you're ready
            File.WriteAllText(args[1], "READY");

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string encoding = Console.ReadLine();
                string fileOutput = Console.ReadLine();

                // You should not ignore the encoding as we do.
                ParseFile(input, fileOutput);

                Console.WriteLine("OK");
            }
        }

        static void ParseFile(string input, string output)
        {
            if (File.ReadAllText(input).IndexOf("mTimeout") < 0)
            {
                ParseSource(input, output);
                return;
            }

            ParseDestination(input, output);
        }

        static void ParseSource(string input, string output)
        {
            using (StreamWriter writer = new StreamWriter(output, false))
            {
                writer.WriteLine("---");
                writer.WriteLine("type: file");
                writer.WriteLine("name: {0}", input);
                writer.WriteLine("locationSpan : {start: [1,0], end: [12,1]}");
                writer.WriteLine("footerSpan : [0,-1]");
                writer.WriteLine("parsingErrorsDetected : false");
                writer.WriteLine("children:");

                writer.WriteLine("  - type : class");
                writer.WriteLine("    name : Socket");
                writer.WriteLine("    locationSpan : {start: [1,0], end: [12,1]}");
                writer.WriteLine("    headerSpan : [0, 16]");
                writer.WriteLine("    footerSpan : [186, 186]");
                writer.WriteLine("    children :");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Connect");
                writer.WriteLine("      locationSpan : {start: [3, 0], end: [7,2]}");
                writer.WriteLine("      span : [17, 109]");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Disconnect");
                writer.WriteLine("      locationSpan : {start: [8,0], end: [11,6]}");
                writer.WriteLine("      span : [110, 185]");
            }
        }

        static void ParseDestination(string input, string output)
        {
            using (StreamWriter writer = new StreamWriter(output, false))
            {
                writer.WriteLine("---");
                writer.WriteLine("type: file");
                writer.WriteLine("name: {0}", input);
                writer.WriteLine("locationSpan : {start: [1,0], end: [14,1]}");
                writer.WriteLine("footerSpan : [0,-1]");
                writer.WriteLine("parsingErrorsDetected : false");
                writer.WriteLine("children:");

                writer.WriteLine("  - type : class");
                writer.WriteLine("    name : Socket");
                writer.WriteLine("    locationSpan : {start: [1,0], end: [14,1]}");
                writer.WriteLine("    headerSpan : [0, 20]");
                writer.WriteLine("    footerSpan : [200, 200]");
                writer.WriteLine("    children :");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Disconnect");
                writer.WriteLine("      locationSpan : {start: [5, 0], end: [9,2]}");
                writer.WriteLine("      span : [21, 98]");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Connect");
                writer.WriteLine("      locationSpan : {start: [10,0], end: [13,6]}");
                writer.WriteLine("      span : [99, 199]");
            }
        }
    }
}
