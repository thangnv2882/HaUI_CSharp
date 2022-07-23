using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6._1
{
    internal class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        private static int cnt = 1;

        public Person(string name, string address)
        {
            this.id = cnt++;
            this.name = name;
            this.address = address;
        }

        public Person()
        {
            this.id = cnt++;

        }

        public void Input()
        {
            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Address: ");
            address = Console.ReadLine();
        }

        public void Output()
        {
            string str = String.Format("{0, -8}{1, -20}{2, -25}", id, name, address);
            Console.Write(str);
        }
    }
}
