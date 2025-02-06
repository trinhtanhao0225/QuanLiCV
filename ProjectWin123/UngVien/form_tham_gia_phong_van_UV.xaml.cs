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
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for form_tham_gia_phong_van_UV.xaml
    /// </summary>
    public partial class form_tham_gia_phong_van_UV : Window
    {
        ViewModels.CongViec CongViec;
        ViewModels.UngVien UngVien;
        SqlConnection sqlCon;
        public form_tham_gia_phong_van_UV(ViewModels.CongViec congViec, ViewModels.UngVien ungVien)
        {

            InitializeComponent();
            CongViec = congViec;
            UngVien = ungVien;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            txtTenCongTy.Text = CongViec.TenCongTy;
            txtTenUngVien.Text = UngVien.TenUngVien;
            txtViTri.Text = CongViec.ViTri;
            txtViTriTuyenDung.Text = CongViec.TenCongViec;

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
            sqlCmd.CommandText = " SELECT thoi_gian_phong_van from PhongVan where ma_cong_ty='"+CongViec.MaCongTy+"' and ma_cong_viec='"+CongViec.IdCongViec+"' and can_cuoc_cong_dan='"+UngVien.CanCuocCongDan+"'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                txtThoiGian.Text = reader.GetDateTime(0).ToString();
            }
            reader.Close();
        }
    }
}
