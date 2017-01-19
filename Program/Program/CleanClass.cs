using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DesktopCleaner
{
    public static class CreateTree
    {
        static string pathFile;

        public static void Scan(this string path, string punct)
        {
            DirectoryInfo direct = new DirectoryInfo(path);
            DirectoryInfo[] listOfDir = direct.GetDirectories();

            foreach (DirectoryInfo dd in listOfDir)
            {

                if (dd.Attributes == FileAttributes.Directory)
                {
                    if (dd == listOfDir.Last())
                    {

                        pathFile = path + "\\" + dd;
                        DirectoryInfo director = new DirectoryInfo(pathFile);
                        DirectoryInfo[] array = director.GetDirectories();
                        foreach (DirectoryInfo dir in array)
                        {
                            TimeSpan dif = DateTime.Now.Date - dir.CreationTime.Date;
                            if (dif.TotalDays <= 1)
                                dir.Delete(true);
                        }



                        try
                        {
                            pathFile = path + "\\" + dd;
                            DirectoryInfo di = new DirectoryInfo(pathFile);
                            FileInfo[] arr = di.GetFiles();
                            foreach (FileInfo file in arr)
                            {
                                TimeSpan dif = DateTime.Now.Date - file.CreationTime.Date;
                                if (dif.TotalDays <= 1)
                                    file.Delete();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The process failed: {0}", e.ToString());
                        }

                    }
                    else
                    {
                        pathFile = path + "\\" + dd;
                        DirectoryInfo director = new DirectoryInfo(pathFile);
                        DirectoryInfo[] array = director.GetDirectories();
                        foreach (DirectoryInfo dir in array)
                        {
                            TimeSpan dif = DateTime.Now.Date - dir.CreationTime.Date;
                            if (dif.TotalDays <= 1)
                                dir.Delete(true);
                        }

                        try
                        {
                            pathFile = path + "\\" + dd;
                            DirectoryInfo di = new DirectoryInfo(pathFile);
                            FileInfo[] arr = di.GetFiles();
                            foreach (FileInfo file in arr)
                            {
                                TimeSpan dif = DateTime.Now.Date - file.CreationTime.Date;
                                if (dif.TotalDays <= 1)
                                    file.Delete();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The process failed: {0}", e.ToString());
                        }
                    }

                    try
                    {
                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + dd);
                        DirectoryInfo[] listOfDirs = dir.GetDirectories();
                        if (listOfDirs.Length > 0)
                        {

                            if (dd != listOfDir.Last())
                            {
                                Scan(path + "\\" + dd, punct + "  ");
                            }
                            else
                            {
                                Scan(path + "\\" + dd, punct + "  ");
                            }
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
