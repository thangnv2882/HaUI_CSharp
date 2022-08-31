using System;
using System.Collections.Generic;
using System.Text;

namespace Bai6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>();

            do
            {
                Console.WriteLine("1. Thêm 1 sinh viên.");
                Console.WriteLine("2. Hiển thị danh sách sinh viên.");
                Console.WriteLine("3. Tìm kiếm sinh viên theo id.");
                Console.WriteLine("4. Tìm kiếm sinh viên theo địa chỉ.");
                Console.WriteLine("5. Xóa 1 sinh viên theo id");
                Console.WriteLine("6. Thoát chương trình.");

                Console.Write("Nhập lựa chọn: ");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Student student = new Student();
                        student.Input();
                        students.Add(student);
                        break;

                    case 2:
                        showTitle();
                        getStudents(students);
                        break;

                    case 3:
                        Console.Write("Nhập id sinh viên cần tìm: ");
                        int idFind = int.Parse(Console.ReadLine());

                        showTitle();
                        FindById(students, idFind);
                        break;

                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm: ");
                        string address = Console.ReadLine();

                        showTitle();
                        FindByAddress(students, address);
                        break;

                    case 5:
                        Console.Write("Nhập id sinh viên cần xóa: ");
                        int idDelete = int.Parse(Console.ReadLine());

                        DeleteStudentById(students, idDelete);
                        break;

                    case 6:
                        Console.WriteLine("Thoát chương trình.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

            } while (true);
        }
        static void getStudents(List<Student> students)
        {
            students.ForEach(student =>
            {
                student.Output();
            });
        }

        static void FindById(List<Student> students, int idFind)
        {
            int cnt = 0;
            students.ForEach(student =>
            {
                if (student.id == idFind)
                {
                    cnt++;
                    student.Output();
                }
            });
            if (cnt == 0)
                Console.WriteLine("Không tồn tại sinh viên có id là: " + idFind);
        }

        static void FindByAddress(List<Student> students, string address)
        {
            int cnt = 0;

            students.ForEach(student =>
            {
                if (student.address.Equals(address))
                {
                    cnt++;
                    student.Output();
                }
            });
            if (cnt == 0)
                Console.WriteLine("Không có sinh viên nào ở: " + address);
        }

        static void DeleteStudentById(List<Student> students, int idDelete)
        {
            int cnt = 0;
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].id == idDelete)
                {
                    students.Remove(students[i]);
                    Console.WriteLine("\tDelete success");
                    cnt++;
                    break;
                }
            }

            if(cnt == 0)
                Console.WriteLine("Không tồn tại sinh viên có id là: " + idDelete);
        }

        static void showTitle()
        {
            Console.WriteLine("\t\tTHÔNG TIN DANH SÁCH STUDENT");
            string str = String.Format("{0, -8}{1, -20}{2, -25}{3, -10}{4, -10}{5, -10}", "Id", "Name", "Address", "Math", "Physics", "Total");
            Console.WriteLine(str);
        }

        
    }
}
