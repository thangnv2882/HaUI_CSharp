using System;
using System.Collections.Generic;

namespace Bai6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            List<Vehicles> vehicles = new List<Vehicles>();

            int choose;
            do
            {
                Console.WriteLine("========= MENU =========");
                Console.WriteLine("1. Nhập dữ liệu.");
                Console.WriteLine("2. Hiển thị dữ liệu.");
                Console.WriteLine("3. Tìm kiếm theo id.");
                Console.WriteLine("4. Tìm kiếm theo maker.");
                Console.WriteLine("5. Sắp xếp theo price.");
                Console.WriteLine("6. Sắp xếp theo year.");
                Console.WriteLine("7. Kết thúc.");
                Console.Write("Nhập lựa chọn của bạn: ");
                choose = int.Parse(Console.ReadLine());

                switch(choose)
                {
                    case 1:
                        InputData(vehicles);
                        break;
                    case 2:
                        ShowData(vehicles);
                        break;
                    case 3:
                        Console.Write("Nhập id cần tìm kiếm: ");
                        string idFind = Console.ReadLine();
                        FindById(vehicles, idFind);
                        break;
                    case 4:
                        Console.Write("Nhập hãng sản xuất cần tìm kiếm: ");
                        string maker = Console.ReadLine();
                        Title();
                        FindByMaker(vehicles, maker);
                        break;
                    case 5:
                        SortByPrice(vehicles);
                        break;
                    case 6:
                        SortByYear(vehicles);
                        break;
                    case 7:
                        Console.WriteLine("Thoát chương trình");
                        Environment.Exit(0);
                        break;
                   

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

            } while(true);


        }

        static void InputData(List<Vehicles> vehicles)
        {
            vehicles.Add(new Car("v1", "BMW", "Model 1", 2020, 19999, "Đen"));
            vehicles.Add(new Car("v2", "Audi", "Model 2", 2021, 23999, "Đỏ"));
            vehicles.Add(new Car("v3", "Mazda", "Model 3", 2019, 21999, "Trắng"));
            vehicles.Add(new Truck("v4", "Huyndai", "Model 4", 2016, 13999, 2));
            vehicles.Add(new Truck("v5", "THACO", "Model 5", 2022, 11999, 3));
            vehicles.Add(new Truck("v6", "MITSUBISHI", "Model 6", 2018, 12999, 4));
        }
        static void ShowData(List<Vehicles> vehicles)
        {
            Title();
            vehicles.ForEach(item =>
            {
                Console.WriteLine(item.ToString());
            });
        }

        static void Title()
        {
            Console.WriteLine(String.Format("{0, -8}{1, -15}{2, -25}{3, -10}{4, -10}",
                            "Id", "Maker", "Model", "Year", "Price"));
        }

        static void FindById(List<Vehicles> vehicles, string idFind)
        {
            int cnt = 0;
            vehicles.ForEach(item =>
            {
                if (item.id.CompareTo(idFind) == 0)
                {
                    item.Output();
                    cnt++;
                }
            });
            if(cnt == 0)
            {
                Console.WriteLine("Không có chiếc xe nào có id là: " + idFind);
            }

        }

        static void FindByMaker(List<Vehicles> vehicles, string maker)
        {
            int cnt = 0;
            vehicles.ForEach(item =>
            {
                if (item.maker.CompareTo(maker) == 0)
                {
                    Console.WriteLine(item.ToString());
                    cnt++;
                }
            });

            if (cnt == 0)
            {
                Console.WriteLine("Không có chiếc xe nào có hãng sản xuất là: " + maker);
            }

        }
        static void SortByPrice(List<Vehicles> vehicles)
        {
            Console.WriteLine("Danh sách trước khi sắp xếp.");
            ShowData(vehicles);

            for(int i = 0; i < vehicles.Count-1; i++)
                for(int j = i+1; j < vehicles.Count; j++)
                    if (vehicles[i].price > vehicles[j].price)
                        (vehicles[i], vehicles[j]) = (vehicles[j], vehicles[i]);
                    

            Console.WriteLine("Danh sách sau khi sắp xếp theo giá.");
            ShowData(vehicles);

        }

        static void SortByYear(List<Vehicles> vehicles)
        {
            Console.WriteLine("Danh sách trước khi sắp xếp.");
            ShowData(vehicles);

            for (int i = 0; i < vehicles.Count - 1; i++)
                for (int j = i + 1; j < vehicles.Count; j++)
                    if (vehicles[i].year > vehicles[j].year)
                        (vehicles[i], vehicles[j]) = (vehicles[j], vehicles[i]);


            Console.WriteLine("Danh sách sau khi sắp xếp theo năm sản xuất.");
            ShowData(vehicles);

        }
    }
}
