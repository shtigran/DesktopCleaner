using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DesktopCleaner;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\tCleaner Master\n");
            Console.WriteLine("Delete temporary folders and files (which have created in last day) \non Your Desktop ");


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path.Scan("");

            Console.WriteLine("\n\nWork is done!");

            DirectoryInfo director = new DirectoryInfo(path);
            DirectoryInfo[] array = director.GetDirectories();
            foreach (DirectoryInfo dir in array)
            {
                TimeSpan dif = DateTime.Now.Date - dir.CreationTime.Date;
                if (dif.TotalDays <= 1)
                    dir.Delete(true);
            }

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] arr = di.GetFiles();
            foreach (FileInfo file in arr)
            {
                TimeSpan dif = DateTime.Now.Date - file.CreationTime.Date;
                if (dif.TotalDays <= 1)
                    file.Delete();
            }
            Console.ReadKey();
        }
    }
}

