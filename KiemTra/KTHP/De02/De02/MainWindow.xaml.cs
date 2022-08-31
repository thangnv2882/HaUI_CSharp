using De02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace De02
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

        QuanLySanPhamDBContext db = new QuanLySanPhamDBContext();

        public void showSB()
        {
            var query = from nh in db.NhomHangs
                        select nh;
            CBHang.ItemsSource = query.ToList();
            CBHang.DisplayMemberPath = "TenNhomHang";
            CBHang.SelectedValuePath = "MaNhomHang";
            CBHang.SelectedIndex = -1;
        }
        public void ShowData()
        {
            var query = from sp in db.SanPhams
                        join nh in db.NhomHangs 
                        on sp.MaNhomHang equals nh.MaNhomHang
                        orderby sp.SoLuongBan descending
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            nh.TenNhomHang,
                            TienBan = sp.tienBan()
                        };
            dg.ItemsSource = query.ToList();
        }


        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                Type t = dg.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                txtMa.Text = p[0].GetValue(dg.SelectedItem).ToString();
                txtTen.Text = p[1].GetValue(dg.SelectedItem).ToString();
                txtDG.Text = p[2].GetValue(dg.SelectedItem).ToString();
                txtSL.Text = p[3].GetValue(dg.SelectedItem).ToString();
                CBHang.Text = p[4].GetValue(dg.SelectedItem).ToString();
            }
        }

        public Boolean checkDL()
        {
            string t = "";
            if(txtMa.Text.CompareTo("") == 0 
                || txtTen.Text.CompareTo("") == 0
                || txtDG.Text.CompareTo("") == 0
                || txtSL.Text.CompareTo("") == 0
                || CBHang.Text.CompareTo("") == 0)
            {
                t += "Vui lòng nhập đầy đủ dữ liệu";
            }
            else
            {
                int a;
                if(!int.TryParse(txtMa.Text, out a))
                {
                    t += "Mã sản phẩm phải là số nguyên";
                }
                if (!int.TryParse(txtSL.Text, out a))
                {
                    t += "Số lượng bán phải là số nguyên";
                }
                else
                {
                    if(int.Parse(txtSL.Text) < 1)
                    {
                        t += "Số lượng bán phải >= 1";
                    }
                }
                float b;
                if (!float.TryParse(txtDG.Text, out b))
                {
                    t += "Đơn giá phải là số thực";
                }
            }
            if(t.CompareTo("") != 0)
            {
                MessageBox.Show(t, "Thông báo");
                return false;
            }
            return true;
        }
        private void Them(object sender, RoutedEventArgs e)
        {
            if(checkDL())
            {
                var query = db.SanPhams.SingleOrDefault(t => t.MaSp == int.Parse(txtMa.Text));
                if(query != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại");
                    return;
                }
                else
                {
                    SanPham sp = new SanPham();
                    sp.MaSp = int.Parse(txtMa.Text);
                    sp.TenSanPham = txtTen.Text;
                    sp.DonGia = float.Parse(txtDG.Text);
                    sp.SoLuongBan = int.Parse(txtSL.Text);

                    NhomHang itemSelected = (NhomHang)CBHang.SelectedItem;
                    sp.MaNhomHang = itemSelected.MaNhomHang;

                    db.SanPhams.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                    ShowData();
                }
            }
        }
        private void Sua(object sender, RoutedEventArgs e)
        {
            if (checkDL())
            {
                var itemEdit = db.SanPhams.SingleOrDefault(t => t.MaSp == int.Parse(txtMa.Text));
                if (itemEdit != null)
                {
                    itemEdit.TenSanPham = txtTen.Text;
                    itemEdit.DonGia = float.Parse(txtDG.Text);
                    itemEdit.SoLuongBan = int.Parse(txtSL.Text);

                    NhomHang itemSelected = (NhomHang)CBHang.SelectedItem;
                    itemEdit.MaNhomHang = itemSelected.MaNhomHang;

                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                    ShowData();
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào được chọn.");
                }
            }       
        }

        private void Xoa(object sender, RoutedEventArgs e)
        {
            if (checkDL())
            {
                var itemDel = db.SanPhams.SingleOrDefault(t => t.MaSp == int.Parse(txtMa.Text));
                if (itemDel != null)
                {
                    MessageBoxResult result = MessageBox.Show("Xác nhận xoá?", "Thông báo", MessageBoxButton.YesNo);
                    if(result == MessageBoxResult.Yes)
                    {
                        db.SanPhams.Remove(itemDel);
                        db.SaveChanges();
                        MessageBox.Show("Xoá thành công");
                        ShowData();
                    }
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào được chọn.");
                }
            }
        }
        private void Tim(object sender, RoutedEventArgs e)
        {
            var query = from sp in db.SanPhams
                        join nh in db.NhomHangs
                        on sp.MaNhomHang equals nh.MaNhomHang
                        where sp.MaNhomHang == 1
                        orderby sp.SoLuongBan descending
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            nh.TenNhomHang,
                            TienBan = sp.tienBan()
                        };
            Window1 w1 = new Window1();
            w1.dg1.ItemsSource = query.ToList();
            w1.Show();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showSB();
            ShowData();
        }
    }


}
