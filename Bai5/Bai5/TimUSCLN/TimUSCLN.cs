using System;
namespace TimUSCLN
{
    internal class TimUSCLN
    {
        public int sothu1 { get; set; }

        public int sothu2 { get; set; }

        public TimUSCLN()
        {
        }

        public TimUSCLN(int sothu1, int sothu2)
        {
            this.sothu1 = sothu1;
            this.sothu2 = sothu2;
        }

        public void Nhap()
        {
            Console.Write("Số thứ 1: ");
            sothu1 = int.Parse(Console.ReadLine());
            Console.Write("Số thứ 2: ");
            sothu2 = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("Số thứ 1: " + sothu1);
            Console.WriteLine("Số thứ 2: " + sothu2);
        }

        public int Solve(int sothu1, int sothu2)
        {
            if (sothu2 == 0)
                return sothu1;
            return Solve(sothu2, sothu1 % sothu2);
        }
    }
}
