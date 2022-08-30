
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

        public void HienThiCB()
        {
            var query = from khoa in db.Khoas
                        select khoa;
            CbKhoa.ItemsSource = query.ToList();
            CbKhoa.DisplayMemberPath = "TenKhoa";
            CbKhoa.SelectedValuePath = "MaKhoa";
            CbKhoa.SelectedIndex = -1;
        }
        public void HienThiDuLieu()
        {
            dg.Items.Clear();
            var query = from bn in db.BenhNhans
                        orderby bn.SoNgayNamVien descending
                        select bn;
            for (int i = 0; i < query.ToList().Count; i++)
            {
                BenhNhan benhNhan = query.ToList()[i];
                dg.Items.Add(benhNhan);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDuLieu();
        }

        private void Them(object sender, RoutedEventArgs e)
        {
            if(CheckDL())
            {
                BenhNhan benhNhan = new BenhNhan();
                benhNhan.MaBn = int.Parse(tbMabn.Text);
                benhNhan.HoTen = tbTen.Text;

                Khoa itemSelected = (Khoa)CbKhoa.SelectedItem;
                int maKhoa = itemSelected.MaKhoa;
                benhNhan.MaKhoa = maKhoa;
                benhNhan.SoNgayNamVien = int.Parse(tbSoNgay.Text);
                benhNhan.VienPhi = int.Parse(tbSoNgay.Text) * 200000;
                db.BenhNhans.Add(benhNhan);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                HienThiDuLieu();
            }
        }
        public Boolean CheckDL()
        {
            string tb = "";
            if (tbMabn.Text.CompareTo("") == 0
                || tbTen.Text.CompareTo("") == 0
                || tbDc.Text.CompareTo("") == 0
                || tbSoNgay.Text.CompareTo("") == 0
                || CbKhoa.Text.CompareTo("") == 0)
            {
                tb += "Vui lòng nhập đầy đủ dữ liệu";
            }
            else
            {
                int a;
                if (!int.TryParse(tbMabn.Text, out a))
                {
                    tb += "\nMã bênh nhân phải là số nguyên";
                }
                else
                {
                    var query = db.BenhNhans.SingleOrDefault(t => t.MaBn == int.Parse(tbMabn.Text));
                    if (query != null)
                    {
                        tb += "\nMã bệnh nhân đã tồn tại";
                    }
                }
                if (!int.TryParse(tbSoNgay.Text, out a))
                {
                    tb += "\nSố ngày nằm viện phải là số nguyên";
                }
                else if (int.Parse(tbSoNgay.Text) < 1)
                {
                    tb += "Số ngày nằm viện phải >= 1";
                }
                
                
            }
            
            if(tb != "")
            {
                MessageBox.Show(tb, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        //public Boolean checkMaBn(int maBn)
        //{
        //    var query = from bn in db.BenhNhans
        //                orderby bn.SoNgayNamVien descending
        //                select bn;
        //    for (int i = 0; i < query.ToList().Count; i++)
        //    {
        //        if (query.ToList()[i].MaBn == maBn)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        private void Sua(object sender, RoutedEventArgs e)
        {
            var itemEdit = db.BenhNhans.SingleOrDefault(t => tbMabn.Text != "" ? t.MaBn == int.Parse(tbMabn.Text) : false);
            //if (CheckDL())
            //{
            if (itemEdit != null)
            {
                itemEdit.MaBn = int.Parse(tbMabn.Text);
                itemEdit.HoTen = tbTen.Text;

                Khoa itemSelected = (Khoa)CbKhoa.SelectedItem;
                int maKhoa = itemSelected.MaKhoa;

                itemEdit.MaKhoa = maKhoa;
                itemEdit.SoNgayNamVien = int.Parse(tbSoNgay.Text);
                itemEdit.VienPhi = int.Parse(tbSoNgay.Text) * 200000;

                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Khong co item de sua");

            }
        }

        private void Xoa(object sender, RoutedEventArgs e)
        {
            var itemDel = db.BenhNhans.SingleOrDefault(t => tbMabn.Text != "" ? t.MaBn == int.Parse(tbMabn.Text): false);
            if (itemDel != null)
            {
                MessageBoxResult result = MessageBox.Show("Vui long xac nhan xoa", "Thong bao", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.BenhNhans.Remove(itemDel);
                    db.SaveChanges();
                    MessageBox.Show("Xoa thanh cong");
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Khong co item de xoa");
            }
        }

        private void Tim(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.dgW2.Items.Clear();
            var query = from bn in db.BenhNhans
                        where bn.MaKhoa == 1
                        select bn;
            for (int i = 0; i < query.ToList().Count; i++)
            {
                BenhNhan benhNhan = query.ToList()[i];
                window1.dgW2.Items.Add(benhNhan);
            }
            window1.Show();

        }

        private void dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                try
                {
                    Type t = dg.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();

                    tbMabn.Text = p[0].GetValue(dg.SelectedValue).ToString();
                    tbTen.Text = p[1].GetValue(dg.SelectedValue).ToString();
                    CbKhoa.SelectedValue = p[4].GetValue(dg.SelectedValue).ToString();
                    tbSoNgay.Text = p[2].GetValue(dg.SelectedValue).ToString();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
