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
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for mo_ta_cong_ty_UV.xaml
    /// </summary>
    public partial class mo_ta_cong_ty_UV : Window
    {
        ViewModels.CongViec CongViec = null;
        SqlConnection sqlCon;
        public mo_ta_cong_ty_UV(CongViec congViec)
        {
            InitializeComponent();
            CongViec = congViec;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            ViewModels.CongTy CongTy = null;
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string query = "select * from CongTy where ma_cong_ty='" + CongViec.MaCongTy + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string tenCongTy = reader.GetString(0);
                    string linhVuc = reader.GetString(2);
                    string giayPhep = reader.GetString(3);
                    string diaChi = reader.GetString(4);
                    string nguoiDungDau = reader.GetString(5);
                    string canCuocCongDan = reader.GetString(6);
                    string soDienThoai = reader.GetString(7);
                    string maSoThue = reader.GetString(8);
                    string anhCongTy = reader.GetString(9);
                    string moTa = reader.GetString(10);
                    CongTy = new ViewModels.CongTy(tenCongTy, CongViec.MaCongTy, linhVuc, giayPhep, diaChi, nguoiDungDau, canCuocCongDan, soDienThoai, maSoThue, anhCongTy, moTa);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            txtTenCongTy.Text = CongTy.TenCongTy;
            txtLinhVuc.Text = CongTy.LinhVuc;
            txtMoTaCongTy.Text = CongTy.MoTa;
            txtNguoiDungDan.Text = CongTy.NguoiDungDau;
            txtSoDienThoai.Text = CongTy.SoDienThoai;

            Uri fileUri = new Uri(CongTy.AnhCongTy, UriKind.Absolute);
            BitmapImage bitmap1 = new BitmapImage(fileUri);
            imgCongTy.Source = bitmap1;

            Uri fileUri2 = new Uri(CongTy.GiayPhep, UriKind.Absolute);
            BitmapImage bitmap2 = new BitmapImage(fileUri);
            imgGiayPhep.Source = bitmap2;
        }
    }
}