using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6._1
{
    internal class Student:Person
    {
        public byte math { get; set; }
        public byte physics { get; set; }

        public void Input()
        {
            base.Input();
            Console.Write("Math: ");
            math = byte.Parse(Console.ReadLine());

            Console.Write("Physics: ");
            physics = byte.Parse(Console.ReadLine());

        }

        public void Output()
        {
            base.Output();
            string str = String.Format("{0, -10}{1, -10}{2, -10}", math, physics, Total());
            Console.WriteLine(str);
        }

        public byte Total()
        {
            return (byte)(math + physics);
        }
    }
}
