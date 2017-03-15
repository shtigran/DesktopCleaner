# Desktop  Temprory Folders and Files Cleaner
# C#6.0  .NET FRAMEWORK 4.6

----
### Test and Result

![gif source](https://github.com/shtigran/DesktopCleaner/blob/master/GIF.gif)
----

This program allow You delete temprory folders and files (and all subfolders and subfiles) on the desktop. In principle it is possible to make this program for any folder or directory.

----
### Purpose
Suppose You need every evening delete all unnecessary files from Your desktop created by other peoples. Yoo need only run this program.

###  DesktopCleaner namespace description
```c#
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
```
 
Here we check all folders and subfolders to fine temprorary files or folders and then delete them. 

### Program class implementation 
```c#
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
```

### Description of Program class

Here we connect the path to desktop directoy for all users. Then inwoke the Scan method with path argument. The Scan method delete all subfiles and subfolders. From the program we delete folders and files on current desktop directory.


