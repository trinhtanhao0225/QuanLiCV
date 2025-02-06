using ProjectWin123.UngVien;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
using System.Data.SqlClient;
using System.Data;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for menu_form_CT.xaml
    /// </summary>
    public partial class menu_form_CT : Window
    {
        ViewModels.CongTy CongTy=null;
        SqlConnection sqlCon = null;

        public menu_form_CT(string maCongTy)
        {
            InitializeComponent();
            loadDuLieu(maCongTy);
            
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void loadDuLieu(string maCongTy)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
                string query = "select * from CongTy where ma_cong_ty='"+maCongTy+"'";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = cmd.ExecuteReader();

                  if (reader.Read())
                    {
                        string tenCongTy=reader.GetString(0).Trim();
                        string linhVuc=reader.GetString(2).Trim();
                        string giayPhep=reader.GetString(3).Trim();
                        string diaChi = reader.GetString(4).Trim();
                        string nguoiDungDau = reader.GetString(5).Trim();
                        string canCuocCongDan=reader.GetString(6).Trim();
                        string soDienThoai = reader.GetString(7).Trim();
                        string maSoThue = reader.GetString(8).Trim();
                        string anhCongTy = reader.GetString(9).Trim();
                        string moTa = reader.GetString(10).Trim();
                        CongTy = new ViewModels.CongTy(tenCongTy, maCongTy, linhVuc, giayPhep, diaChi, nguoiDungDau, canCuocCongDan, soDienThoai, maSoThue,anhCongTy,moTa);
                }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
           
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
        private void CV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Hide();
        }
        private void ds_jobs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        private void mota_cong_viec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        private void ds_yeu_thich_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CongTy != null)
            {
                UC_danh_sach_CV_yeu_thich ds_yeu_thich = new UC_danh_sach_CV_yeu_thich(CongTy);
                main_CT.Content = null;
                main_CT.Content = ds_yeu_thich;
            }
        }
        private void quan_li_nhan_su_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CongTy != null)
            {
                UC_quan_li_nhan_su quan_li_nhan_su = new UC_quan_li_nhan_su();
                main_CT.Content = null;
                main_CT.Content = quan_li_nhan_su;
            }
              

        }
        private void xac_nhan_CV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           if(CongTy != null)
            {
                UC_xac_nhan_CV xac_nhan_CV = new UC_xac_nhan_CV(CongTy);
                main_CT.Content = null;
                main_CT.Content = xac_nhan_CV;
            }
        }
        private void tao_viec_lam_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(CongTy != null)
            {
                UC_tao_cong_viec_CT tao_cong_viec = new UC_tao_cong_viec_CT(CongTy);
                main_CT.Content = null;
                main_CT.Content = tao_cong_viec;
            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

                login_form lg_form = new login_form();
                this.Hide();
                lg_form.Show();
     
        }

        private void ds_phong_van_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CongTy != null)
            {
                UC_danh_sach_phong_van uC_Danh_Sach_Phong_Van = new UC_danh_sach_phong_van(CongTy);
                main_CT.Content = null;
                main_CT.Content = uC_Danh_Sach_Phong_Van;
            }
        }
    }
}
