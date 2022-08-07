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

namespace Bai9._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
        }


        public void init()
        {
            List<String> names = new List<String>();
            names.Add("Nguyễn Văn Thắng");
            names.Add("Nguyễn Văn Thắng 1");
            names.Add("Nguyễn Văn Thắng 2");

            listName.ItemsSource = names;
        }

        private void Button_Click_Tinh(object sender, RoutedEventArgs e)
        {
            int sd = int.Parse(tbChiSoMoi.Text) - int.Parse(tbChiSoCu.Text);
            tbTieuThu.Text = sd.ToString();
            if(sd > 50)
            {
                tbTrongDM.Text = 50.ToString();
                tbVuotDM.Text = (int.Parse(tbTieuThu.Text) - 50).ToString();
            }
            else
            {
                tbTrongDM.Text = tbTieuThu.Text;
                tbVuotDM.Text = 0.ToString();
            }

            int soTienPhaiTra = int.Parse(tbTrongDM.Text) * 500 + int.Parse(tbVuotDM.Text) * 1000;
            tbPhaiTra.Text = soTienPhaiTra.ToString();

        }

        private void Button_Click_In(object sender, RoutedEventArgs e)
        {
            tbShow.Text = listName.Text 
                + "\nSo kw tiêu thụ: " 
                + tbTieuThu.Text
                + "\nTổng tiền: " 
                + tbPhaiTra.Text;


        }
    }
}
