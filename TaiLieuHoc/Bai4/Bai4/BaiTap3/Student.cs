using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public float mark { get; set; }
        public int scholarship { get; set; }

        public Student(int id, string name, float mark, int scholarship)
        {
            this.id = id;
            this.name = name;
            this.mark = mark;
            this.scholarship = scholarship;
        }

        public Student(int id)
        {
            this.id = id;
        }

        public Student()
        {
        }


        public void Input()
        {
            Console.Write("Id: ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Mark: ");
            mark = float.Parse(Console.ReadLine());

            if (mark > 8)
                scholarship = 500;
            else if (mark >= 7 && mark <= 8)
                scholarship = 300;
            else
                scholarship = 0;
        }

        public void Output()
        {
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Mark: " + mark);
            Console.WriteLine("Scholarship: " + scholarship);
        }

    }
}
