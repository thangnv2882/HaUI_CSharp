using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCoSo
{
    internal class Program
    {
        static char[] kytu =
                            {
                                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                'U', 'V', 'X', 'Y', 'Z', 'W'
                            };
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            

            int n, heSo;
            Console.Write("Nhập số nguyên N: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập hệ cơ số: ");
            heSo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Số {0} sau khi chuyển đổi từ hệ 10 sang hệ {1} là: {2}", n, heSo, ConvertDecimalToX(n, heSo));

            Console.WriteLine("Số {0} sau khi chuyển đổi từ hệ {1} sang hệ 10 là: {2}", n, heSo, ConvertXToDecimal(n, heSo));



        }

        static String ConvertDecimalToX(int n, int heSo)
        {
            char[] ketqua = new char[100];
            if (n == 0)
                return "0";
            else
            {
                int i = 0;
                while (n != 0)
                {
                    int temp = n % heSo;
                    n /= heSo;

                    ketqua[i++] = kytu[temp];
                }
                Array.Reverse(ketqua);
                String s = new string(ketqua);
                return s;
            }
        }

        static int ConvertXToDecimal(int n, int heSo)
        {
            List<int> so = new List<int>();
            if (n == 0)
                return 0;
            else
            {
                while (n != 0)
                {
                    int temp = n % 10;
                    n /= 10;

                    so.Add(temp);
                }

                int kq = 0;
                for(int j = 0; j < so.Count; j++)
                {
                    if (so[j] != 0)
                        kq += so[j] * (int)Math.Pow(heSo, j);
                }
                return kq;
            }
        }
    }
}
