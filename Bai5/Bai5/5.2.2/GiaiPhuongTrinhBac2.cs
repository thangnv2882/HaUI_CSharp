using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2._2
{
    internal class GiaiPhuongTrinhBac2
    {
        public int a { get; set; }

        public int b { get; set; }

        public int c { get; set; }

        public void Solve()
        {
            if (a == 0)
            {
                //if (b == 0)
                //{
                //    if (c == 0)
                //    {
                //        Console.WriteLine("Phương trình có vô số nghiệm.");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Phương trình vô nghiệm.");
                //    }
                //}
                //else
                //{
                //    if (c == 0)
                //    {
                //        Console.WriteLine("Phương trình có vô số nghiệm.");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Phương trình có nghiệm duy nhất: " + -c / b);
                //    }
                //}

                Console.WriteLine("Không phải phương trình bậc 2");
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta > 0)
                {
                    double x1 = Math.Round((-b + Math.Sqrt(delta)) / (2 * a), 3);
                    double x2 = Math.Round((-b - Math.Sqrt(delta)) / (2 * a), 3); ;
                    Console.WriteLine("Phương trình có 2 nghiệm: x1 = {0}, x2 = {1}", x1, x2);
                }
                else if (delta == 0)
                {
                    Console.WriteLine("Phương trình có nghiệm kép: x1 = x2 = {0}", -b / (2.0 * a));
                }
                else
                {
                    Console.WriteLine("Phương trình vô nghiệm");
                }
            }
        }
    }
}
