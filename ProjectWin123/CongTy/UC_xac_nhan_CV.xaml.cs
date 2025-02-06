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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using ProjectWin123.ViewModels;
using System.Data;
using System.Collections;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for UC_xac_nhan_CV.xaml
    /// </summary>
    public partial class UC_xac_nhan_CV : UserControl
    {
        SqlConnection sqlCon = null;
        ViewModels.CongTy CongTy = null;
        ViewModels.CongViec CongViec = null;
        CongTyDAO CongTyDAO = new CongTyDAO();
        public UC_xac_nhan_CV(ViewModels.CongTy congTy)
        {
            InitializeComponent();
            CongTy = congTy;
            load_du_lieu();

        }
        private void load_du_lieu()
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
            sqlCmd.CommandText = @"SELECT CongViec.ma_cong_ty, 
                              CongViec.ten_cong_ty,
                              CongViec.logo_cong_ty,
                              CongViec.id_cong_viec, 
                              CongViec.ten_cong_viec, 
                              CongViec.anh_cong_viec, 
                              CongViec.vi_tri, 
                              CongViec.luong, 
                              CongViec.kinh_nghiem, 
                              CongViec.ngay_tuyen, 
                              CongViec.ngay_ket_thuc, 
                              CongViec.mo_ta, 
                              CongViec.ki_nang, 
                              CongViec.loai_cong_viec, 
                              CongViec.cap_bac, 
                              CongViec.hoc_van,
                              CongViec.gioi_tinh, 
                              CongViec.nganh_nghe, 
                              CongViec.ten_lien_he, 
                              CongViec.vi_tri_cu_the, 
                              CongViec.ve_cong_ty 
                       FROM CongViec 
                       LEFT JOIN QuanLiCongViec 
                       ON CongViec.id_cong_viec = QuanLiCongViec.id_cong_viec 
                          AND CongViec.ma_cong_ty = QuanLiCongViec.ma_cong_ty 
                       WHERE QuanLiCongViec.id_cong_viec IS NULL 
                          AND CongViec.ma_cong_ty = '" + CongTy.MaCongTy + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();

            StackPanel stackPanel_main = this.FindName("frame_cong_viec") as StackPanel;


            if (stackPanel_main != null)
            {
                while (reader.Read())
                {
                    string maCongTy = reader.GetString(0);
                    string tenCongTy = reader.GetString(1);
                    string logoCongTy = reader.GetString(2);
                    string idCongViec = reader.GetString(3);
                    string tenCongViec = reader.GetString(4);
                    string anhCongViec = reader.GetString(5);
                    string viTri = reader.GetString(6);
                    int luong = reader.GetInt32(7);
                    string kinhNghiem = reader.GetString(8);
                    DateTime ngayTuyen = reader.GetDateTime(9);
                    DateTime ngayKetThuc = reader.GetDateTime(10);
                    string moTa = reader.GetString(11);
                    string kiNang = reader.GetString(12);
                    string loaiCongViec = reader.GetString(13);
                    string capBac = reader.GetString(14);
                    string hocVan = reader.GetString(15);
                    string gioiTinh = reader.GetString(16);
                    string nganhNghe = reader.GetString(17);
                    string tenLienHe = reader.GetString(18);
                    string viTriCuThe = reader.GetString(19);
                    string veCongTy = reader.GetString(20);
                    CongViec = new CongViec(maCongTy, tenCongTy, logoCongTy, idCongViec, tenCongViec, anhCongViec, viTri, luong, kinhNghiem, ngayTuyen, ngayKetThuc, moTa, kiNang, loaiCongViec, capBac, hocVan, gioiTinh, nganhNghe, tenLienHe, viTriCuThe, veCongTy);
                    UC_card_cong_viec_CT newCard = new UC_card_cong_viec_CT(CongViec); // Tạo một bản sao mới của UserControl
                    newCard.CongViecSent += UserControl_StringSent;
                    newCard.Width = 300;
                    newCard.Height = 75;
                    newCard.Margin = new Thickness(10);
                    stackPanel_main.Children.Add(newCard);
                }
                reader.Close();
            }
        }
        private void UserControl_StringSent(object sender, ViewModels.CongViec congViec)
        {
            CongViec = congViec;

            txtTenCongViec.Text = CongViec.TenCongViec;
            txtLuong.Text = CongViec.Luong.ToString();
            txtKinhNghiem.Text = CongViec.KinhNghiem;

            load_du_lieu_bang();
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
            dataTable.Columns.Add("Ten", typeof(string));
            dataTable.Columns.Add("NgheNghiep", typeof(string));
            dataTable.Columns.Add("CanCuocCongDan", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ten_ung_vien,nghe_nghiep,UngVien.can_cuoc_cong_dan,so_dien_thoai,email from UngVien right join DangKiCongViec on UngVien.can_cuoc_cong_dan=DangKiCongViec.can_cuoc_cong_dan where ma_cong_viec='" + CongViec.IdCongViec + "' and ma_cong_ty='" + CongViec.MaCongTy + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ten = reader.GetString(0);
                string ngheNghiep = reader.GetString(1);
                string canCuocCongDan = reader.GetString(2);
                string soDienThoai = reader.GetString(3);
                string email = reader.GetString(4);
                dataTable.Rows.Add(ten, ngheNghiep, canCuocCongDan, soDienThoai, email);
            }
            reader.Close();
            dataGrid_NV.ItemsSource = dataTable.DefaultView;
        }
        private void btnMoTa_Click(object sender, RoutedEventArgs e)
        {
            if (txtLuong.Text == "")
            {
                MessageBox.Show("Vui long chon cong viec muon xem");
            }
            else
            {
                mo_ta_cong_viec_form_CT moTa_cong_viec = new mo_ta_cong_viec_form_CT(CongViec);
                moTa_cong_viec.Show();
            }
        }

        private void btn_opencv_ClickEvent(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ dataGrid_NV
            DataRowView selectedRow = (DataRowView)dataGrid_NV.SelectedItem;

            if (selectedRow != null)
            {
                // Lấy giá trị của cột "CanCuocCongDan" từ dòng được chọn
                string canCuocCongDan = selectedRow["CanCuocCongDan"].ToString();

                // Tạo một đối tượng công việc và mở form chi tiết công việc với căn cước công dân tương ứng
                ViewModels.CongViec CongViec = null; // Bạn có thể cung cấp đối tượng công việc tương ứng nếu cần
                CV_form_CT cv_form_CT = new CV_form_CT(canCuocCongDan, CongViec);
                cv_form_CT.Show();
            }
        }
        private void btn_deletecv_ClickEvent(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid_NV.SelectedItem;

            if (selectedRow != null)
            {
                // Lấy giá trị của cột "CanCuocCongDan" từ dòng được chọn
                string canCuocCongDan = selectedRow["CanCuocCongDan"].ToString();
                CongTyDAO.xoaUngVien(CongViec, canCuocCongDan);

            }
        }
        private void btnSubmit_ClickEvent(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ dataGrid_NV
            DataRowView selectedRow = (DataRowView)dataGrid_NV.SelectedItem;

            if (selectedRow != null)
            {
                // Lấy giá trị của cột "CanCuocCongDan" từ dòng được chọn
                string canCuocCongDan = selectedRow["CanCuocCongDan"].ToString();

                form_xac_nhan_phong_van form_Xac_Nhan_Phong_Van = new form_xac_nhan_phong_van(CongViec, canCuocCongDan);
                form_Xac_Nhan_Phong_Van.Show();
            }
        }


    }
}