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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.UngVien
{
    public partial class UC__tien_trinh_cong_viec_UV : UserControl
    {
        ViewModels.UngVien UngVien = null;
        SqlConnection sqlCon;
        public UC__tien_trinh_cong_viec_UV(ViewModels.UngVien ungVien)
        {
            InitializeComponent();
            UngVien = ungVien;
            Loaded += UC_tien_trinh_cong_viec_UV_Loaded;
            loadThongBao();
        }
        private void UC_tien_trinh_cong_viec_UV_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromSQL();
        }
        /*private void LoadDataFromSQL()
        {
            // Tạo DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IdCongViec", typeof(string));
            dataTable.Columns.Add("TenCongViec", typeof(string));
            dataTable.Columns.Add("TienDo", typeof(string));
            dataTable.Columns.Add("Luong", typeof(string));

            // Thực hiện truy vấn SQL
            string query = "SELECT QuanLiCongViec.id_cong_viec, CongViec.ten_cong_viec, QuanLiCongViec.trang_thai, CongViec.luong FROM CongViec " +
                "           join QuanLiCongViec on QuanLiCongViec.id_cong_viec = CongViec.id_cong_viec where QuanLiCongViec.id_nguoi_lam = '" + UngVien.CanCuocCongDan + "'";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                // Đọc dữ liệu từ SqlDataReader và điền vào DataTable
                while (reader.Read())
                {
                    string idCongViec = reader.GetString(0);
                    string tenCongViec = reader.GetString(1);
                    int tienDo = reader.GetInt32(2);
                    string luong = reader.GetInt32(3).ToString();

                    dataTable.Rows.Add(idCongViec, tenCongViec, tienDo, luong);
                    if (tienDo < 100)
                        ListView_dangtienhanh.DataContext = dataTable.DefaultView;
                    else if (tienDo == 100)
                        ListView_hoanthanh.DataContext = dataTable.DefaultView;
                    else
                        ListView_quahan.DataContext = dataTable.DefaultView;
                }
                reader.Close();
            }

            // Gán DataTable làm nguồn dữ liệu cho ListView
            
        }*/
        private void LoadDataFromSQL()
        {
            try
            {
                DataTable dataTableHoanThanh = new DataTable(); // DataTable cho ListView_hoanthanh
                dataTableHoanThanh.Columns.Add("MaCongTy", typeof(string));
                dataTableHoanThanh.Columns.Add("IdCongViec", typeof(string));
                dataTableHoanThanh.Columns.Add("TenCongViec", typeof(string));
                dataTableHoanThanh.Columns.Add("TienDo", typeof(string));
                dataTableHoanThanh.Columns.Add("Luong", typeof(string));

                DataTable dataTableDangTienHanh = new DataTable(); // DataTable cho ListView_dangtienhanh
                dataTableDangTienHanh.Columns.Add("MaCongTy", typeof(string));
                dataTableDangTienHanh.Columns.Add("IdCongViec", typeof(string));
                dataTableDangTienHanh.Columns.Add("TenCongViec", typeof(string));
                dataTableDangTienHanh.Columns.Add("TienDo", typeof(string));
                dataTableDangTienHanh.Columns.Add("Luong", typeof(string));

                DataTable dataTableQuaHan = new DataTable(); // DataTable cho ListView_quahan
                dataTableQuaHan.Columns.Add("MaCongTy", typeof(string));
                dataTableQuaHan.Columns.Add("IdCongViec", typeof(string));
                dataTableQuaHan.Columns.Add("TenCongViec", typeof(string));
                dataTableQuaHan.Columns.Add("TienDo", typeof(string));
                dataTableQuaHan.Columns.Add("Luong", typeof(string));

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    connection.Open();

                    // Thực hiện truy vấn SQL
                    string query = "SELECT QuanLiCongViec.ma_cong_ty, QuanLiCongViec.id_cong_viec, CongViec.ten_cong_viec, QuanLiCongViec.trang_thai, CongViec.luong FROM CongViec   join QuanLiCongViec on QuanLiCongViec.id_cong_viec = CongViec.id_cong_viec and QuanLiCongViec.ma_cong_ty=CongViec.ma_cong_ty  where QuanLiCongViec.id_nguoi_lam = '" + UngVien.CanCuocCongDan + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Đọc dữ liệu từ SqlDataReader và điền vào DataTables tương ứng
                    while (reader.Read())
                    {
                        string maCongTy = reader.GetString(0);
                        string idCongViec = reader.GetString(1);
                        string tenCongViec = reader.GetString(2);
                        string tienDo = reader.GetString(3);
                        string luong = reader.GetInt32(4).ToString();

                        if (Convert.ToInt32(tienDo) == 100)
                        {
                            dataTableHoanThanh.Rows.Add(maCongTy, idCongViec, tenCongViec, tienDo, luong);
                        }
                        else if (Convert.ToInt32(tienDo) < 100)
                        {
                            dataTableDangTienHanh.Rows.Add(maCongTy, idCongViec, tenCongViec, tienDo, luong);
                        }
                        else
                        {
                            dataTableQuaHan.Rows.Add(maCongTy, idCongViec, tenCongViec, tienDo, luong);
                        }
                    }
                    reader.Close();

                    // Gán dữ liệu từ DataTables vào các ListView tương ứng
                    ListView_hoanthanh.ItemsSource = dataTableHoanThanh.DefaultView;
                    ListView_dangtienhanh.ItemsSource = dataTableDangTienHanh.DefaultView;
                    ListView_quahan.ItemsSource = dataTableQuaHan.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DeleteButton_Click1(object sender, EventArgs e)
        {

        }
        private void DeleteButton_Click2(object sender, EventArgs e)
        {

        }
        private void DeleteButton_Click3(object sender, EventArgs e)
        {

        }
        private void loadThongBao()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            StackPanel stackpanel_main = this.FindName("frame_thong_bao") as StackPanel;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT CongViec.ma_cong_ty,CongViec.ten_cong_ty,CongViec.logo_cong_ty,CongViec.id_cong_viec,CongViec.ten_cong_viec,CongViec.anh_cong_viec,CongViec.vi_tri,CongViec.luong,CongViec.kinh_nghiem,CongViec.ngay_tuyen,CongViec.ngay_ket_thuc,CongViec.mo_ta,CongViec.ki_nang,CongViec.loai_cong_viec,CongViec.cap_bac,CongViec.hoc_van,CongViec.gioi_tinh,CongViec.nganh_nghe,CongViec.ten_lien_he,CongViec.vi_tri_cu_the,CongViec.ve_cong_ty,ket_qua_xin_viec from KetQuaXinViec left join CongViec on CongViec.ma_cong_ty=KetQuaXinViec.ma_cong_ty and CongViec.id_cong_viec=KetQuaXinViec.id_cong_viec Where can_cuoc_cong_dan='" + UngVien.CanCuocCongDan + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                ViewModels.CongViec CongViec = new ViewModels.CongViec(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), reader.GetString(18),reader.GetString(19),reader.GetString(20));
                UC_thong_bao_dang_ki_UV uC_Thong_Bao_Dang_Ki_UV = new UC_thong_bao_dang_ki_UV(CongViec, UngVien, reader.GetInt32(21).ToString());
                uC_Thong_Bao_Dang_Ki_UV.Width = 1110;
                uC_Thong_Bao_Dang_Ki_UV.Height = 70;
                uC_Thong_Bao_Dang_Ki_UV.Margin = new Thickness(5);
                frame_thong_bao.Children.Add(uC_Thong_Bao_Dang_Ki_UV);
            }
            reader.Close();
        }
    }
}

