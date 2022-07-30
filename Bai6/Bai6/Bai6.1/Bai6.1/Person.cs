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

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Person()
        {
        }

        public virtual void Input()
        {

            Console.Write("Id: ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Address: ");
            address = Console.ReadLine();
        }

        public virtual void Output()
        {
            string str = String.Format("{0, -8}{1, -20}{2, -25}", id, name, address);
            Console.Write(str);
        }
    }
}
