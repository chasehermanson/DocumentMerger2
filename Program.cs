using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMerger2

{

    class Program

    {

        static void Main(string[] args)

        {
            int argCount;
            String content = "";

            if (args.Length < 3)
            {

                Console.WriteLine("DocumentMerger2<inputFile1> < inputFile2 > ... < inputFileN > < outputFile >");
                Console.WriteLine("Supply A List Of Text Files To Merge Followed By The Name Of The Resulting Merged Text File As Command Line Arguments.");
                Console.WriteLine();

            }

            else

            {

                argCount = args.Length;
                for (int i = 0; i < args.Length - 1; i++)

                {
                    Console.WriteLine("Merge File: " + args[i]);
                    while (!File.Exists(args[i]))

                    {
                        Console.WriteLine("File " + args[i] + " Was Not Found. Please Enter A Valid File.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                    try

                    {
                        content += System.IO.File.ReadAllText(args[i]);

                    }

                    catch (Exception y)

                    {
                        Console.WriteLine(y.ToString());
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine("New File: " + args[argCount - 1]);

                try
                {
                    using (StreamWriter sw = new StreamWriter(args[argCount - 1]))
                    {
                        sw.WriteLine(content);
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.ToString());
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("Your New File " + args[args.Length - 1] + " Has Been Created.");
            Console.ReadLine();
        }
    }
}