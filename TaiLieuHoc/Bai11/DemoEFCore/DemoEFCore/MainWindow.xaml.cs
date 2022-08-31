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

using DemoEFCore.Models;

namespace DemoEFCore
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Tạo thể hiện của lớp context
            DemoBai11Context db = new DemoBai11Context();
            var query = from lsp in db.LoaiSanPhams
                        select lsp;
            dgvLoaiSanPham.ItemsSource = query.ToList();
        }
    }
}
