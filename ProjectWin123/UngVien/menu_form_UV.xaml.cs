using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for menu_form_UV.xaml
    /// </summary>
    public partial class menu_form_UV : Window
    {
        ViewModels.UngVien UngVien = null;
        SqlConnection sqlCon = null;
        public menu_form_UV(string canCuocCongDan)
        {
            InitializeComponent();
            loadDuLieu(canCuocCongDan);
        }
        private void loadDuLieu(string canCuocCongDan)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string query = "select * from UngVien where can_cuoc_cong_dan='" + canCuocCongDan + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string tenUngVien = reader.GetString(0);
                    string ngheNghiep = reader.GetString(1);
                    DateTime ngaySinh = reader.GetDateTime(3);
                    string gioiTinh = reader.GetString(4);
                    string soDienThoai = reader.GetString(5);
                    string email = reader.GetString(6);
                    string diaChi = reader.GetString(7);
                    int tinHoc = reader.GetInt32(8);
                    int tiengAnh = reader.GetInt32(9);
                    string mucTieu = reader.GetString(10);
                    string hocVan = reader.GetString(11);
                    string kinhNghiem = reader.GetString(12);
                    string hoatDong = reader.GetString(13);
                    string chungChi = reader.GetString(14);
                    string danhHieu = reader.GetString(15);
                    string thongTinThem = reader.GetString(16);
                    UngVien = new ViewModels.UngVien(tenUngVien, ngheNghiep, canCuocCongDan, ngaySinh, gioiTinh, soDienThoai, email, diaChi, tinHoc, tiengAnh, mucTieu, hocVan, kinhNghiem, hoatDong, chungChi, danhHieu, thongTinThem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseOverTarget(thanh_chuc_nang, e) && ButtonCloseMenu.Visibility == Visibility.Visible)
            {

                Storyboard storyboard = (Storyboard)FindResource("CloseMenu");
                storyboard.Begin();
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
                ButtonOpenMenu.Visibility = Visibility.Visible;
            }
        }
        private bool IsMouseOverTarget(UIElement target, MouseButtonEventArgs e)
        {
            Point positionRelativeToTarget = e.GetPosition(target);
            return positionRelativeToTarget.X >= 0 && positionRelativeToTarget.X < target.RenderSize.Width &&
                   positionRelativeToTarget.Y >= 0 && positionRelativeToTarget.Y < target.RenderSize.Height;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CV_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            if (UngVien != null)
            {
                CV_form cv_form = new CV_form(UngVien);
                cv_form.Show();
                this.Hide();
            }
        }
        private void ds_jobs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (UngVien != null)
            {
                UC_cong_viec cong_viec = new UC_cong_viec(UngVien);
                main_UV.Content = null;
                main_UV.Content = cong_viec;
            }

        }
        private void mota_cong_viec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        private void tuyen_nhan_vien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }
        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            login_form lg_form = new login_form();
            this.Hide();
            lg_form.Show();
        }
        private void tientrinh_cong_viec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (UngVien != null)
            {
                UC__tien_trinh_cong_viec_UV tien_trinh_cong_viec = new UC__tien_trinh_cong_viec_UV(UngVien);
                main_UV.Content = null;
                main_UV.Content = tien_trinh_cong_viec;
            }
        }
    }
}
