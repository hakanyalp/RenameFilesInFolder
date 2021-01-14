using System;
using System.IO;
using System.Linq;

namespace RenameDirectory
{
    class Program
    {
        static void Main()
        {
            //string imagesPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Yapay Zeka Resimleri\\";
            string imagesPath = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(imagesPath);
            FileInfo[] allFiles = d.GetFiles().Where(f => f.Extension != ".exe").ToArray();

            Console.Write(allFiles.Length + " dosya bulundu, dosyaları yeniden isimlendirilirken başına eklenecek yazı girin : ");
            string startedText = Console.ReadLine();
            
            int count = 1;
            foreach (FileInfo f in allFiles)
            {
                string[] fileNameParts = f.FullName.Split('.');
                string extension = fileNameParts[fileNameParts.Length - 1];
                //string deneme = f.FullName.Replace("abc_", count + ".jpg");
                File.Move(f.FullName, $"{imagesPath}\\{startedText}_{count}.{extension}");
                count++;
            }

            Console.WriteLine("\nİşlem tamam, herhangi bir tuşa basarak kapatabilirsiniz");
            Console.ReadKey();
        }
    }
}
