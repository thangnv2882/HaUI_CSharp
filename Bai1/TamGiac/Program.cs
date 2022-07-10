using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamGiac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;
            Console.WriteLine("Nhập độ dài 3 cạnh của tam giác");
            x = Convert.ToDouble(Console.ReadLine());
            y = System.Double.Parse(Console.ReadLine());
            z = Convert.ToDouble(Console.ReadLine());

            if(x > 0 && y > 0 && z > 0
                && x + y > z && z + z > y && y + z > x)
            {
                double cv = x + y + z;
                double p = cv / 2;
                double s = Math.Sqrt(p * (p - x) * (p - y) * (p - z));

                Console.WriteLine(cv);
                Console.WriteLine(s);
            } 
            else
            {
                Console.WriteLine("Không phải là tam giác.");
            }
            
        }
    }
}
