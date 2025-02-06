using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for CV_form_CT.xaml
    /// </summary>
    public partial class CV_form_CT : Window
    {
        SqlConnection sqlCon = null;
        ViewModels.CongViec CongViec;
        ViewModels.UngVien UngVien;
        CongTyDAO congTyDAO = new CongTyDAO();
        bool flag = false;
        public CV_form_CT(string cancuoccongdan, ViewModels.CongViec congViec)
        {

            InitializeComponent();
            load_du_lieu(cancuoccongdan,congViec);
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void myLabel_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void myLabel_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void load_du_lieu(string canCuocCongDan,ViewModels.CongViec congViec)
        {
            CongViec = congViec;
            List<string> dataSource = new List<string> { "Nam", "Nữ" };

            // Đặt nguồn dữ liệu cho ComboBox
            cbGioiTinh.ItemsSource = dataSource;
            // Thực hiện xử lý với chuỗi nhận được
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * from UngVien Where can_cuoc_cong_dan='" + canCuocCongDan + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                UngVien=new ViewModels.UngVien(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetDateTime(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetString(7),reader.GetInt32(8),reader.GetInt32(9),reader.GetString(10),reader.GetString(11),reader.GetString(12),reader.GetString(13),reader.GetString(14),reader.GetString(15),reader.GetString(16));    
                txtTen.Text = UngVien.TenUngVien;
                txtNgheNghiep.Text = UngVien.NgheNghiep;
                txtCanCuocCongDan.Text = canCuocCongDan;
                datepickerNgaySinh.Text = UngVien.NgaySinh.ToString();
                cbGioiTinh.Text = UngVien.GioiTinh;
                txtPhone.Text = UngVien.SoDienThoai;
                txtEmail.Text = UngVien.Email;
                txtDiaChi.Text = UngVien.DiaChi;
                txtTinHoc.Value = UngVien.TinHoc;
                txtTiengAnh.Value = UngVien.TiengAnh;
                txtMucTieu.Text = UngVien.MucTieu;
                txtHocVan.Text = UngVien.HocVan;
                txtKinhNghiem.Text = UngVien.KinhNghiem;
                txtHoatDong.Text = UngVien.HoatDong;
                txtChungChi.Text = UngVien.ChungChi;
                txtThongTin.Text = UngVien.ThongTinThem;
            }
            flag = true;
            MessageBox.Show("dafafa");
            reader.Close();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            congTyDAO.capNhatCVYeuThich(CongViec, UngVien);

        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            
        }
        private void BasicRatingBarFractional_ValueChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_MouseDown(object sender, MouseButtonEventArgs e)
        {
        

        }
    }
}
