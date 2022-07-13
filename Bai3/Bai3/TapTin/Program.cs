using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TapTin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string sourcePath = "D:/Fighting/KyPhu4/.NET/Bai3/Bai3/TapTin/file-mau.txt";
            string targetPath = "D:/Fighting/KyPhu4/.NET/Bai3/Bai3/TapTin/file-copy.txt";


            // Cách 2: StreamReader và StreamWriter
            StreamReader reader = new StreamReader(sourcePath);
            StreamWriter writer = new StreamWriter(targetPath);
            try
            {
                String fileHoa = reader.ReadToEnd().ToUpper();
                String[] fileArr = fileHoa.Split(' ');

                writer.Write(fileHoa);
                writer.WriteLine("\nSố từ : " + fileArr.Length + "\n");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }

            writer.Close();
            reader.Close();

        }
    }
}
