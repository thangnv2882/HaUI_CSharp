using De01.Models;
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

namespace De01
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
        QuanLyBenhNhanDBContext db = new QuanLyBenhNhanDBContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDuLieu();
        }

        public void HienThiCB()
        {
            var query = from k in db.Khoas
                        select k;
            CBKhoa.ItemsSource = query.ToList();
            CBKhoa.DisplayMemberPath = "TenKhoa";
            CBKhoa.SelectedValuePath = "MaKhoa";
            CBKhoa.SelectedIndex = -1;
        }
        public void HienThiDuLieu()
        {
            var query = from bn in db.BenhNhans
                        join k in db.Khoas
                        on bn.MaKhoa equals k.MaKhoa
                        orderby bn.SoNgayNamVien descending
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            k.TenKhoa,
                            bn.SoNgayNamVien,
                            VienPhi = bn.thanhTien()
                        };
            dg.ItemsSource = query.ToList();
        }

        public Boolean CheckDL()
        {
            string t = "";
            if(txtMa.Text.CompareTo("") == 0
                || txtTen.Text.CompareTo("") == 0
                || txtNgay.Text.CompareTo("") == 0
                || txtDC.Text.CompareTo("") == 0
                || CBKhoa.Text.CompareTo("") == 0)
            {
                t += "Vui lòng nhâp đầy đủ dữ liệu";
            }
            else
            {
                int a;
                if(!int.TryParse(txtMa.Text, out a))
                {
                    t += "Mã bênh nhân phải là số nguyên";
                }
                else
                {
                    var query = db.BenhNhans.SingleOrDefault(t => t.MaBn == int.Parse(txtMa.Text));
                    if(query != null)
                    {
                        t += "Mã bệnh nhân đã tồn tại";
                    }
                }
                if (!int.TryParse(txtNgay.Text, out a))
                {
                    t += "Số ngày nằm viện phải là số nguyên";
                }
                else if (int.Parse(txtNgay.Text) < 1)
                {
                    t += "Số ngày nằm viện phải lớn hơn 1";
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
                BenhNhan bn = new BenhNhan();
                bn.MaBn = int.Parse(txtMa.Text);
                bn.HoTen = txtTen.Text;
                bn.SoNgayNamVien = int.Parse(txtNgay.Text);

                Khoa itemSelected = (Khoa)CBKhoa.SelectedItem;
                bn.MaKhoa = itemSelected.MaKhoa;

                bn.VienPhi = bn.SoNgayNamVien * 200000;

                db.BenhNhans.Add(bn);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                HienThiDuLieu();
            } 
        }
        
        //private void Tim(object sender, RoutedEventArgs e)
        //{
        //    txtMa.Text = "Hello";
        //    var query = from bn in db.BenhNhans
        //                join k in db.Khoas
        //                on bn.MaKhoa equals k.MaKhoa
        //                where bn.MaKhoa == 1
        //                select new
        //                {
        //                    bn.MaBn,
        //                    bn.HoTen,
        //                    k.TenKhoa,
        //                    bn.SoNgayNamVien,
        //                    VienPhi = bn.thanhTien()
        //                };
        //    Window1 w1 = new Window1();
        //    w1.dg2.ItemsSource = query.ToList();
        //    w1.Show();
        //}

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                Type t = dg.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                txtMa.Text = p[0].GetValue(dg.SelectedItem).ToString();
                txtTen.Text = p[1].GetValue(dg.SelectedItem).ToString();
                CBKhoa.Text = p[2].GetValue(dg.SelectedItem).ToString();
                txtNgay.Text = p[3].GetValue(dg.SelectedItem).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtMa.Text = "Hello";
            var query = from bn in db.BenhNhans
                        join k in db.Khoas
                        on bn.MaKhoa equals k.MaKhoa
                        where bn.MaKhoa == 1
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            k.TenKhoa,
                            bn.SoNgayNamVien,
                            VienPhi = bn.thanhTien()
                        };
            Window1 w1 = new Window1();
            w1.dg2.ItemsSource = query.ToList();
            w1.Show();
        }
    }
}
