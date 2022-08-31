using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string sourcePath = "D:/Fighting/KyPhu4/.NET/Bai2/Bai2/filesource.txt";
            string targetPath = "D:/Fighting/KyPhu4/.NET/Bai2/Bai2/filetarget.txt";

            // Cách 1: File
            File.Copy(sourcePath, targetPath, true);

            // Cách 2: StreamReader và StreamWriter
            StreamReader reader = new StreamReader(sourcePath);
            StreamWriter writer = new StreamWriter(targetPath);
            try
            {
                writer.Write(reader.ReadToEnd());
            } catch(Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }

            writer.Close();
            reader.Close();

        }
    }
}
