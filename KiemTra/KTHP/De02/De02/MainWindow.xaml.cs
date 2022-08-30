using De02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

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

        public void HienThiCB()
        {
            var query = from hang in db.NhomHangs
                        select hang;
            CBHang.ItemsSource = query.ToList();
            CBHang.DisplayMemberPath = "TenNhomHang";
            CBHang.SelectedValuePath = "MaNhomHang";
            CBHang.SelectedIndex = -1;
        }
        public void HienThiDuLieu()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDuLieu();
        }

        public Boolean checkDL()
        {
            string t = "";
            if(txtMa.Text.CompareTo("") == 0
                || txtTen.Text.CompareTo("") == 0
                || txtSoLuong.Text.CompareTo("") == 0
                || txtDonGia.Text.CompareTo("") == 0
                || CBHang.Text.CompareTo("") == 0)
            {
                t += "Vui lòng nhập đẩy đủ dữ liệu";
            }
            else
            {
                int a;
                if(!int.TryParse(txtMa.Text, out a)) {
                    t += "Mã sản phẩm phải là số nguyên";
                }
                else
                {
                    var query = db.SanPhams.SingleOrDefault(t => t.MaSp == int.Parse(txtMa.Text));
                    if(query != null)
                    {
                        t += "Mã sản phẩm đã tồn tại";
                    }
                }
                if (!int.TryParse(txtSoLuong.Text, out a))
                {
                    t += "\nSố lượng bán phải là số nguyên";
                }
                else
                {
                    if(int.Parse(txtSoLuong.Text) < 1)
                    {
                        t += "\nSố lượng bán phải >= 1";
                    }
                }
                float b;
                if (!float.TryParse(txtDonGia.Text, out b))
                {
                    t += "\nĐơn giá phải là số thực";
                }
            }
            if (t.CompareTo("") != 0)
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
                SanPham sp = new SanPham();
                sp.MaSp = int.Parse(txtMa.Text);
                sp.TenSanPham = txtTen.Text;
                sp.DonGia = float.Parse(txtDonGia.Text);
                sp.SoLuongBan = int.Parse(txtSoLuong.Text);
                NhomHang itemSelected = (NhomHang)CBHang.SelectedItem;
                sp.MaNhomHang = itemSelected.MaNhomHang;
                sp.TienBan = sp.DonGia * sp.SoLuongBan;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                HienThiDuLieu();

            }
        }
        private void Sua(object sender, RoutedEventArgs e)
        {
            var itemEdit = db.SanPhams.SingleOrDefault(t => txtMa.Text.CompareTo("") != 0 ? int.Parse(txtMa.Text) == t.MaSp : false);
            if(itemEdit != null)
            {
                itemEdit.MaSp = int.Parse(txtMa.Text);
                itemEdit.TenSanPham = txtTen.Text;
                itemEdit.DonGia = float.Parse(txtDonGia.Text);
                itemEdit.SoLuongBan = int.Parse(txtSoLuong.Text);
                NhomHang itemSelected = (NhomHang)CBHang.SelectedItem;
                itemEdit.MaNhomHang = itemSelected.MaNhomHang;
                itemEdit.TienBan = itemEdit.DonGia * itemEdit.SoLuongBan;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm được chọn");
            }
        }
        private void Xoa(object sender, RoutedEventArgs e)
        {
            var itemDel = db.SanPhams.SingleOrDefault(t => txtMa.Text.CompareTo("") != 0 ? int.Parse(txtMa.Text) == t.MaSp : false);
            if (itemDel != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có xác nhận xoá không?", "Xác nhận", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(itemDel);
                    db.SaveChanges();
                    MessageBox.Show("Xoá thành công");
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm được chọn");
            }
        }
        private void Tim(object sender, RoutedEventArgs e)
        {
            var query = from sp in db.SanPhams
                        join nh in db.NhomHangs
                        on sp.MaNhomHang equals nh.MaNhomHang
                        where sp.MaNhomHang == 1
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            nh.TenNhomHang,
                            TienBan = sp.tienBan()
                        };
            Window1 window1 = new Window1();
            window1.dg2.ItemsSource = query.ToList();
            window1.Show();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                Type t = dg.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                txtMa.Text = p[0].GetValue(dg.SelectedValue).ToString();
                txtTen.Text = p[1].GetValue(dg.SelectedValue).ToString();
                txtDonGia.Text = p[2].GetValue(dg.SelectedValue).ToString();
                txtSoLuong.Text = p[3].GetValue(dg.SelectedValue).ToString();
                CBHang.Text = p[4].GetValue(dg.SelectedValue).ToString();
            }
            
        }
    }
}
