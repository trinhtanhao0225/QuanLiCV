using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
using System.Collections;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for CV_form.xaml
    /// </summary>
    public partial class CV_form : Window
    {
        ViewModels.UngVien UngVien = null;
        SqlConnection sqlCon = null;
        UngVienDAO ungVienDAO = new UngVienDAO();
        public CV_form(ViewModels.UngVien ungVien)
        {

            InitializeComponent();

            UngVien = ungVien;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            List<string> dataSource = new List<string> { "Nam", "Nữ" };
            // Đặt nguồn dữ liệu cho ComboBox
            cbGioiTinh.ItemsSource = dataSource;
            txtTen.Text = UngVien.TenUngVien;
            txtNgheNghiep.Text = UngVien.NgheNghiep;
            txtCanCuocCongDan.Text = UngVien.CanCuocCongDan;
            dpBirthDay.Text = UngVien.NgaySinh.ToString();
            cbGioiTinh.Text = UngVien.GioiTinh;
            txtSoDienThoai.Text = UngVien.SoDienThoai;
            txtEmail.Text = UngVien.Email;
            txtDiaChi.Text = UngVien.DiaChi;
            tinHoc.Value = UngVien.TinHoc;
            tiengAnh.Value = UngVien.TiengAnh;
            txtMucTieu.Text = UngVien.MucTieu;
            txtHocVan.Text = UngVien.HocVan;
            txtKinhNghiem.Text = UngVien.KinhNghiem;
            txtHoatDong.Text = UngVien.HoatDong;
            txtChungChi.Text = UngVien.ChungChi;
            txtDanhHieu.Text = UngVien.DanhHieu;
            txtThongTinThem.Text = UngVien.ThongTinThem;
        }
        public DateTime Today { get; set; } = DateTime.Today;
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void myLabel_MouseEnter(object sender, MouseEventArgs e)
        {
        }
        private void myLabel_MouseLeave(object sender, MouseEventArgs e)
        {
        }
        private void quay_ve(object sender, RoutedEventArgs e)
        {
            menu_form_UV mn_form_UV = new menu_form_UV(UngVien.CanCuocCongDan);
            mn_form_UV.Show();
            this.Hide();
        }
        private void BasicRatingBarFractional_ValueChanged(object sender, RoutedEventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            UngVien = new ViewModels.UngVien(txtTen.Text, txtNgheNghiep.Text, txtCanCuocCongDan.Text, Convert.ToDateTime(dpBirthDay.Text), cbGioiTinh.Text, txtSoDienThoai.Text, txtEmail.Text, txtDiaChi.Text, Convert.ToInt32(tinHoc.Value), Convert.ToInt32(tiengAnh.Value), txtMucTieu.Text, txtHocVan.Text, txtKinhNghiem.Text, txtHoatDong.Text, txtChungChi.Text, txtDanhHieu.Text, txtThongTinThem.Text);

            ungVienDAO.capNhatUngVien(UngVien);
        }
    }
}
