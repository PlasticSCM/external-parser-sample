using System;
using System.IO;

namespace codeparser
{
    class Program
    {
        static void Main(string[] args)
        {
//            System.Threading.Thread.Sleep(10 * 1000);

            // Write the "flagfile" when you're ready
            File.WriteAllText(args[1], "READY");

            string firstFile = Console.ReadLine();
            string firstFileOutput = Console.ReadLine();

            ParseFile(firstFile, firstFileOutput);

            Console.WriteLine("OK");

            string secondFile = Console.ReadLine();
            string secondFileOutput = Console.ReadLine();

            ParseFile(secondFile, secondFileOutput);
            Console.WriteLine("OK");

            string end = Console.ReadLine();

            if (end == "end")
            {
                //Console.WriteLine("Finishing correctly");
                return;
            }

            //Console.WriteLine("Finishing incorrectly, no 'end' command received");
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
                writer.WriteLine("parsingErrorsDetected : true");
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

                writer.WriteLine("parsingError:");
                writer.WriteLine("  - location: [5,45]");
                writer.WriteLine("    message: \"Missing ; at the end of the line\"");
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
