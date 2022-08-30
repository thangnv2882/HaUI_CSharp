using De03.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace De03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        QLNhanvienContext db = new QLNhanvienContext();

        private void HienThiDuLieu()
        {
            var query = from nhanvien in db.Nhanviens
                        orderby nhanvien.Luong ascending
                        select new
                        {
                            nhanvien.MaPhong,
                            nhanvien.MaNv,
                            nhanvien.Hoten,
                            nhanvien.Luong,
                            nhanvien.Thuong,
                            TongTien = nhanvien.Luong + nhanvien.Thuong
                        };
            dg.ItemsSource = query.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from nhanvien in db.Nhanviens
                        where nhanvien.Luong > 5000
                        orderby nhanvien.Luong ascending
                        select new
                        {
                            nhanvien.MaPhong,
                            nhanvien.MaNv,
                            nhanvien.Hoten,
                            nhanvien.Luong,
                            nhanvien.Thuong,
                            TongTien = nhanvien.Luong + nhanvien.Thuong
                        };
            dg.ItemsSource = query.ToList();
        }
    }
}
