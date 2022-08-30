using De04.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace De04
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
        QLBanHangContext db = new QLBanHangContext();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiTheoSL();
        }
        public void HienThiCB()
        {
            var query = from dm in db.DanhMucHangs
                        select dm;
            cbDM.ItemsSource = query.ToList();
            cbDM.DisplayMemberPath = "TenDm";
            cbDM.SelectedValuePath = "MaDm";
            cbDM.SelectedIndex = -1;
        }
        public void HienThiTheoSL()
        {
            var query = from hang in db.Hangs
                        where hang.SoLuongCon <= 200
                        orderby hang.TenHang descending
                        select new
                        {
                            hang.MaHang,
                            hang.TenHang,
                            hang.MaDm,
                            hang.DonGiaBan,
                            hang.SoLuongCon,
                            ThanhTien = hang.thanhTien()
                        };
            dg.ItemsSource = query.ToList();
        }

        public void HienThiDuLieu()
        {
            var query = from hang in db.Hangs
                        select new
                        {
                            hang.MaHang,
                            hang.TenHang,
                            hang.MaDm,
                            hang.DonGiaBan,
                            hang.SoLuongCon,
                            ThanhTien = hang.thanhTien()
                        };
            dg.ItemsSource = query.ToList();
        }

        public Boolean CheckDL()
        {
            string t = "";
            if(txtMa.Text.CompareTo("") == 0
                || txtTen.Text.CompareTo("") == 0
                || txtGia.Text.CompareTo("") == 0
                || txtSL.Text.CompareTo("") == 0
                || cbDM.Text.CompareTo("") == 0)
            {
                t += "Vui lòng nhập đầy đủ dữ liệu";
            }
            else
            {
                int a;
                if(int.TryParse(txtSL.Text, out a)) {
                    if(int.Parse(txtSL.Text) <= 0)
                    {
                        t += "\nSố lượng có phải lớn hơn 0.";
                    }
                }
                else
                {
                    t += "\nSố lượng có phải là sô nguyên";
                }
                if (int.TryParse(txtGia.Text, out a))
                {
                    if (int.Parse(txtGia.Text) <= 0)
                    {
                        t += "\nĐơn giá phải lớn hơn 0.";
                    }
                }
                else
                {
                    t += "\nĐơn giá phải là sô nguyên";
                }
            }
            if(t.CompareTo("") != 0)
            {
                MessageBox.Show(t);
                return false;
            }
            return true;
        }

        private void Them(object sender, RoutedEventArgs e)
        {
            if(CheckDL())
            {
                Hang hang = new Hang();
                hang.MaHang = txtMa.Text;
                hang.TenHang = txtTen.Text;
                hang.SoLuongCon = int.Parse(txtSL.Text);
                hang.DonGiaBan = int.Parse(txtGia.Text);
                DanhMucHang itemSelected = (DanhMucHang)cbDM.SelectedItem;
                hang.MaDm = itemSelected.MaDm;

                db.Hangs.Add(hang);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                HienThiDuLieu();
            }
        }
        
        private void Sua(object sender, RoutedEventArgs e)
        {
            var itemEdit = db.Hangs.SingleOrDefault(t => txtMa.Text.CompareTo("") != 0 ? txtMa.Text.CompareTo(t.MaHang)==0 : false);
            if(itemEdit != null)
            {
                if (CheckDL())
                {
                    itemEdit.MaHang = txtMa.Text;
                    itemEdit.TenHang = txtTen.Text;
                    itemEdit.SoLuongCon = int.Parse(txtSL.Text);
                    itemEdit.DonGiaBan = int.Parse(txtGia.Text);
                    DanhMucHang itemSelected = (DanhMucHang)cbDM.SelectedItem;
                    itemEdit.MaDm = itemSelected.MaDm;

                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không có mặt hàng nào được chọn.");
            }
        }
        
        private void Xoa(object sender, RoutedEventArgs e)
        {
            var itemDel = db.Hangs.SingleOrDefault(t => txtMa.Text.CompareTo("") != 0 ? txtMa.Text.CompareTo(t.MaHang) == 0 : false);
            if (itemDel != null)
            {
                MessageBoxResult result = MessageBox.Show("Xác nhận xoá", "Thông báo", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.Hangs.Remove(itemDel);
                    db.SaveChanges();
                    MessageBox.Show("Xoá thành công");
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không có mặt hàng nào được chọn.");
            }
        }

        private void Tim(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            var query = from hang in db.Hangs
                        join dmHang in db.DanhMucHangs
                        on hang.MaDm equals dmHang.MaDm
                        select new {
                            dmHang.MaDm,
                            dmHang.TenDm,
                            TongTien = hang.SoLuongCon * hang.DonGiaBan
                        };

            var results = query.GroupBy(a => new { a.MaDm, a.TenDm })
                .Select(s => new
                {
                    s.Key.MaDm,
                    s.Key.TenDm,
                    TongTien = s.Sum(sum => sum.TongTien)
                });

            window1.dgw1.ItemsSource = results.ToList();
            window1.Show();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Type t = dg.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                txtMa.Text = p[0].GetValue(dg.SelectedValue).ToString();
                txtTen.Text = p[1].GetValue(dg.SelectedValue).ToString();
                cbDM.Text = p[2].GetValue(dg.SelectedValue).ToString();
                txtGia.Text = p[3].GetValue(dg.SelectedValue).ToString();
                txtSL.Text = p[4].GetValue(dg.SelectedValue).ToString();

            }
        }
    }
}
