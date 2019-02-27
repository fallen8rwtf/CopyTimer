using System;
using System.IO;
using System.Diagnostics;

namespace CopyTimer
{
    class Program
    {
        //public static string srcPath = ".\\src";
        //public static string dstPath = ".\\dst";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Specify source path and destination path");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            if (args.Length != 0)
            {
                Console.Clear();
                Stopwatch fileCopyTime = new Stopwatch();
                Stopwatch totalCopyTime = new Stopwatch();

                if (!(System.IO.Directory.Exists(args[1])))
                {
                    System.IO.Directory.CreateDirectory(args[1]);
                }

                string[] Dir = System.IO.Directory.GetFiles(args[0]);
                Console.WriteLine("SRC: " + args[0]);
                Console.WriteLine("DST: " + args[1]);
                Console.WriteLine();

                //Start Global Timer
                totalCopyTime.Start();

                foreach (string file in Dir)
                {

                    //Get size of the file
                    FileInfo f = new FileInfo(file);
                    long s1 = f.Length;

                    //Get file name instead of full path
                    string fileName = Path.GetFileName(file);

                    //Start Timer
                    fileCopyTime.Start();

                    //Copy
                    System.IO.File.Copy(file, args[1] + "\\" + fileName, true);

                    //Stop Times
                    fileCopyTime.Stop();

                    //Log the result
                    Console.WriteLine(fileCopyTime.Elapsed + " || " + s1 + " || " + fileName);

                    //Reset the time
                    fileCopyTime.Reset();
                }

                totalCopyTime.Stop();
                Console.WriteLine();

                Console.WriteLine("Total elapsed time: " + totalCopyTime.Elapsed);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

        }
    }
}
