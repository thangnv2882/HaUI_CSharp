using System;

namespace BaiTap2
{
    internal class Circle
    {
        public double radius { get; set; }

        static double PI = 3.14;

        public Circle(double radius)
        {
            this.radius = radius;
        }


        public Circle()
        {
        }

        public double Area(double radius)
        {
            return radius * radius * PI;
        }

        public double Perimeter(double radius)
        {
            return 2 * PI * radius;
        }
    }
}
