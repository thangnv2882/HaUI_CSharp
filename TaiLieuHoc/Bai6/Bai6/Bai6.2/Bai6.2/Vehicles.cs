using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6._2
{
    class Vehicles : IVehicle
    {
        public string id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public double price { get; set; }

        public Vehicles()
        {
        }

        public Vehicles(double price)
        {
            this.price = price;
        }

        public Vehicles(string id, string maker, string model, int year, double price)
        {
            this.id = id;
            this.maker = maker;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        public virtual void Input()
        {
            Console.Write("Id: ");
            id = Console.ReadLine();
            Console.Write("Maker: ");
            maker = Console.ReadLine();
            Console.Write("Model: ");
            model = Console.ReadLine();
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            price = double.Parse(Console.ReadLine());
        }

        public virtual void Output()
        {
            //Console.WriteLine("Id: " + id);
            //Console.WriteLine("Maker: " + maker);
            //Console.WriteLine("Model: " + model);
            //Console.WriteLine("Year: " + year);
            //Console.WriteLine("Price: " + price);
            Console.Write(String.Format("{0, -8}{1, -15}{2, -25}{3, -10}{4, -10}",
                            id, maker, model, year, price));

        }

        public override bool Equals(object obj)
        {
            Vehicles vehicles = (Vehicles) obj;
            return (this.id.Equals(vehicles.id));
        }

        public override string ToString()
        {
            string str = String.Format("{0, -8}{1, -15}{2, -25}{3, -10}{4, -10}",
                            id, maker, model, year, price);
            return str;
        }

    }
}
