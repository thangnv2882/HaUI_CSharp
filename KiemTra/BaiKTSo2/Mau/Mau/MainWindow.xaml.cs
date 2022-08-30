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

namespace Mau
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nhap_Click(object sender, RoutedEventArgs e)
        {
            if(txtTen.Text == "" || cbLoai.Text == "" || dpNS.Text == "" || txtTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                double tuoi = DateTime.Now.Subtract(dpNS.DisplayDate).TotalDays / 365.2425;
                if(tuoi < 19 || tuoi > 60)
                {
                    MessageBox.Show("Tuổi không thoả mãn");
                }
                else if(int.Parse(txtTien.Text) <= 0)
                {
                    MessageBox.Show("Tiền bán hàng không thoả mãn");
                }
                else
                {
                    double hoaHong = 0;
                    double banHang = double.Parse(txtTien.Text);
                    if (banHang < 1000)
                    {
                        hoaHong = 0;
                    }
                    else if(banHang <= 5000)
                    {
                        hoaHong = banHang * 0.05;
                    }
                    else
                    {
                        hoaHong = banHang * 0.1;
                    }

                    string content =
                        txtTen.Text + " - "
                        + dpNS.Text + " - "
                        + cbLoai.Text
                        + " - Tiền bán hàng: "
                        + txtTien.Text
                        + " - Hoa hồng: "
                        + hoaHong.ToString();
                    lbAll.Items.Add(content);

                }
            }
        }
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            txtTen.Text = "";
            txtTen.Focus();
            cbLoai.Text = "";
            dpNS.Text = DateTime.Now.ToString();
            txtTien.Text = "";
            lbAll.Items.Remove(lbAll.SelectedItem);
        }

        private void Open_Window2(object sender, RoutedEventArgs e)
        {

            Window2 window2 = new Window2();
            string thongtin = lbAll.SelectedItem.ToString();
            string[] tt = thongtin.Split(" - ");

            window2.txtTen2.Text = tt[0];
            window2.dpNS2.Text = tt[1];
            window2.cbLoai2.Text = tt[2];
            window2.txtTien2.Text = tt[3].Substring(15);

            //window2.txtTen2.IsReadOnly = true;
            //window2.cbLoai2.IsReadOnly = true;
            //window2.txtTien2.IsReadOnly = true;

            window2.Show();

        }
    }
}
