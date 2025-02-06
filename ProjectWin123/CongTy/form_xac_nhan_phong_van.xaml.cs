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
    /// Interaction logic for form_xac_nhan_phong_van.xaml
    /// </summary>

    public partial class form_xac_nhan_phong_van : Window
    {
        ViewModels.CongViec CongViec;
        string CanCuocCongDan;
        SqlConnection sqlCon;
        public form_xac_nhan_phong_van(ViewModels.CongViec congViec, string canCuocCongDan)
        {
            InitializeComponent();
            CongViec = congViec;
            CanCuocCongDan = canCuocCongDan;
            load_du_lieu_bang();
        }

        private void btnPhongVan_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thời gian mà người dùng đã chọn từ DatePicker và TimePicker
            DateTime selectedDate = dtpNgayPV.SelectedDate.Value;
            DateTime selectedTime = dtpThoiGianPV.SelectedTime.Value;
            DateTime selectedDateTime = selectedDate.Date + selectedTime.TimeOfDay;

            // Tạo biến để kiểm tra xem có thời gian trùng lặp không
            bool duplicateFound = false;

            // Duyệt qua từng hàng trong DataGrid
            foreach (DataRowView row in dtg_tgphongVan.Items)
            {
                // Kiểm tra nếu thời gian trong hàng hiện tại trùng với thời gian mà người dùng đã chọn
                DateTime rowDateTime = DateTime.Parse(row["ThoiGian"].ToString()); // Điều chỉnh theo kiểu dữ liệu của cột ThoiGian trong DataTable

                // So sánh thời gian
                if (selectedDateTime == rowDateTime)
                {
                    // Nếu trùng, đổi màu sắc của dòng này
                    DataGridRow dataGridRow = (DataGridRow)dtg_tgphongVan.ItemContainerGenerator.ContainerFromItem(row);
                    if (dataGridRow != null)
                    {
                        MessageBox.Show("Trùng lịch phỏng vấn khác");
                        dataGridRow.Background = Brushes.Red;
                        duplicateFound = true;
                        break; // không cần kiểm tra các hàng còn lại nếu đã tìm thấy một hàng trùng lặp
                    }
                }
            }

            // Nếu không tìm thấy dữ liệu trùng lặp, thêm dữ liệu vào cơ sở dữ liệu
            if (!duplicateFound)
            {
                if (CongViec != null)
                {
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
                    sqlCmd.CommandText = "insert into PhongVan (ma_cong_ty,ma_cong_viec,can_cuoc_cong_dan,thoi_gian_phong_van,diem_phong_van) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + CanCuocCongDan + "','" + Convert.ToDateTime(dtpNgayPV.Text + " " + dtpThoiGianPV.Text) + "','0')";
                    sqlCmd.Connection = sqlCon;
                    int kq = sqlCmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Lưu thành công");
                    }
                    if (sqlCon == null)
                    {
                        sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
                    }
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }
                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "insert into KetQuaXinViec (ma_cong_ty,id_cong_viec,can_cuoc_cong_dan,ket_qua_xin_viec) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + CanCuocCongDan + "','1')";
                    sqlCmd.Connection = sqlCon;
                    kq = sqlCmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Lưu thành công");
                    }
                    if (sqlCon == null)
                    {
                        sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
                    }
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }
                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "delete from DangKiCongViec  where ma_cong_ty='" + CongViec.MaCongTy + "'and ma_cong_viec='" + CongViec.IdCongViec + "'and can_cuoc_cong_dan='" + CanCuocCongDan + "'";
                    sqlCmd.Connection = sqlCon;
                    kq = sqlCmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Lưu thành công");
                    }
                }
            }
        }
        private void load_du_lieu_bang()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            DataTable dataTable = new DataTable();
            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Cccd", typeof(string));
            dataTable.Columns.Add("ThoiGian", typeof(string));

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT can_cuoc_cong_dan, thoi_gian_phong_van from PhongVan where ma_cong_ty = '" + CongViec.MaCongTy + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string cccd = reader.GetString(0);
                string thoiGian = reader.GetDateTime(1).ToString();
                dataTable.Rows.Add(cccd, thoiGian);
            }
            reader.Close();
            dtg_tgphongVan.ItemsSource = dataTable.DefaultView;

            // Set width for each column
            dtg_tgphongVan.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star); // Adjust width as needed
            dtg_tgphongVan.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Star); // Adjust width as needed
        }

    }
}