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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for UC_danh_sach_phong_van.xaml
    /// </summary>
    public partial class UC_danh_sach_phong_van : UserControl
    {
        ViewModels.CongTy CongTy;
        SqlConnection sqlCon;
        CongTyDAO CongTyDAO = new CongTyDAO();
        public UC_danh_sach_phong_van(ViewModels.CongTy congTy)
        {
            InitializeComponent();
            CongTy = congTy;
            loadDuLieu();
        }
        private void loadDuLieu()
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
            dataTable.Columns.Add("TenCongViec", typeof(string));
            dataTable.Columns.Add("TenUngVien", typeof(string));
            dataTable.Columns.Add("CanCuocCongDan", typeof(string));
            dataTable.Columns.Add("ThoiGianPhongVan", typeof(string));
            dataTable.Columns.Add("DiemSo", typeof(string));



            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = @"SELECT CongViec.ten_cong_viec,UngVien.ten_ung_vien, PhongVan.can_cuoc_cong_dan, thoi_gian_phong_van,diem_phong_van from PhongVan join CongViec ON PhongVan.ma_cong_viec=CongViec.id_cong_viec and PhongVan.ma_cong_ty=CongViec.ma_cong_ty join UngVien on PhongVan.can_cuoc_cong_dan=UngVien.can_cuoc_cong_dan where PhongVan.ma_cong_ty='"+CongTy.MaCongTy+"'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                dataTable.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetInt32(4).ToString());


                }
                reader.Close();
            dataGridPV.ItemsSource = dataTable.DefaultView;

        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            int diemSo = (Convert.ToInt32(cbKinhNghiem.Text) + Convert.ToInt32(cbChuyenMon.Text) + Convert.ToInt32(cbKiNang.Text) + Convert.ToInt32(cbThichUng.Text) + Convert.ToInt32(cbLangNghe.Text) + Convert.ToInt32(cbLamViec.Text)) / 6;

            CongTyDAO.capNhatPhongvan(diemSo, txtThoiGianPhongVan.Text, CongTy);
        }

        private void dataGridPV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView selectedRow = (DataRowView)dataGridPV.SelectedItem;
            if (selectedRow != null)
            {
               
                // Lấy giá trị của cột "CanCuocCongDan" từ dòng được chọn
                string tenCongViec = selectedRow["TenCongViec"].ToString();
                string tenUngVien = selectedRow["TenUngVien"].ToString();
                string canCuocCongDan = selectedRow["CanCuocCongDan"].ToString();
                string thoiGianPV = selectedRow["ThoiGianPhongVan"].ToString();

                txtTenCongViec.Text = tenCongViec;
                txtTenUngVien.Text = tenUngVien;
                txtCanCuocCongDan.Text = canCuocCongDan;
                txtThoiGianPhongVan.Text = thoiGianPV;
            }
        }

    }
}
