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
                writer.WriteLine("locationSpan : {start: [1,0], end: [22,1]}");
                writer.WriteLine("footerSpan : [0,-1]");
                writer.WriteLine("parsingErrorsDetected : false");
                writer.WriteLine("children :");

                writer.WriteLine("  - type : include");
                writer.WriteLine("    name : sockets");
                writer.WriteLine("    locationSpan : {start: [1, 0], end: [1, 18]}");
                writer.WriteLine("    span : [0, 17]");

                writer.WriteLine("  - type : include");
                writer.WriteLine("    name : system");
                writer.WriteLine("    locationSpan : {start: [2, 0], end: [2,17]}");
                writer.WriteLine("    span : [18, 34]");

                writer.WriteLine("  - type : class");
                writer.WriteLine("    name : Socket");
                writer.WriteLine("    locationSpan : {start: [3,0], end: [22,1]}");
                writer.WriteLine("    headerSpan : [35, 94]");
                writer.WriteLine("    footerSpan : [354, 430]");
                writer.WriteLine("    children :");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Connect");
                writer.WriteLine("      locationSpan : {start: [7, 0], end: [13,6]}");
                writer.WriteLine("      span : [95, 275]");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Disconnect");
                writer.WriteLine("      locationSpan : {start: [14,0], end: [18,6]}");
                writer.WriteLine("      span : [276, 353]");
            }
        }

        static void ParseDestination(string input, string output)
        {
            using (StreamWriter writer = new StreamWriter(output, false))
            {
                writer.WriteLine("---");
                writer.WriteLine("type: file");
                writer.WriteLine("name: {0}", input);
                writer.WriteLine("locationSpan : {start: [1,0], end: [23,1]}");
                writer.WriteLine("footerSpan : [0,-1]");
                writer.WriteLine("parsingErrorsDetected : false");
                writer.WriteLine("children :");

                writer.WriteLine("  - type : include");
                writer.WriteLine("    name : sockets");
                writer.WriteLine("    span : [0, 17]");

                writer.WriteLine("  - type : include");
                writer.WriteLine("    name : system");
                writer.WriteLine("    span : [18, 34]");

                writer.WriteLine("  - type : class");
                writer.WriteLine("    name : Socket");
                writer.WriteLine("    headerSpan : [35, 94]");
                writer.WriteLine("    footerSpan : [366, 442]");
                writer.WriteLine("    children :");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Disconnect");
                writer.WriteLine("      locationSpan : {start: [7, 0], end: [11,6]}");
                writer.WriteLine("      span : [95, 182]");

                writer.WriteLine("    - type : method");
                writer.WriteLine("      name : Connect");
                writer.WriteLine("      locationSpan : {start: [13, 0], end: [19,6]}");
                writer.WriteLine("      span : [183, 365]");
            }
        }
    }
}
