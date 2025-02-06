using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Data.SqlTypes;
using ProjectWin123.CongTy;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for UC_cong_viec.xaml
    /// </summary>

    public partial class UC_cong_viec : UserControl
    {
        ViewModels.UngVien UngVien = null;
        SqlConnection sqlCon = null;
        private HashSet<string> uniqueItems = new HashSet<string>();

        public UC_cong_viec(ViewModels.UngVien ungVien)
        {

            InitializeComponent();
            UngVien = ungVien;
            string query = "";
            load_frame_cong_viec(query);
            loadViTri();
        }
        private void load_frame_cong_viec(string queryplus)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            WrapPanel wrapPanel_main = this.FindName("frame_cong_viec") as WrapPanel;
            wrapPanel_main.Orientation = Orientation.Horizontal;
            scollViewer.Content = wrapPanel_main;

            if (wrapPanel_main != null)
            {
                wrapPanel_main.Children.Clear();
                try
                {
                    string query = string.Format(@"SELECT CongViec.ma_cong_ty, 
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
                       WHERE QuanLiCongViec.id_cong_viec IS NULL {0}", queryplus);
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = cmd.ExecuteReader();
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
                        ViewModels.CongViec CongViec = new CongViec(maCongTy, tenCongTy, logoCongTy, idCongViec, tenCongViec, anhCongViec, viTri, luong, kinhNghiem, ngayTuyen, ngayKetThuc, moTa, kiNang, loaiCongViec, capBac, hocVan, gioiTinh, nganhNghe, tenLienHe, viTriCuThe, veCongTy);
                        UC_card_cong_viec newCard = new UC_card_cong_viec(CongViec, UngVien);
                        newCard.Width = 400;
                        newCard.Height = 200;
                        newCard.Margin = new Thickness(10);
                        wrapPanel_main.Children.Add(newCard);
                        uniqueItems.Add(tenCongViec);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            string query;
            suggestionListBox.Items.Clear();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                foreach (string item in uniqueItems)
                {
                    if (item.ToLower().Contains(searchText))
                    {
                        suggestionListBox.Items.Add(item);
                    }
                }
                suggestionPopup.IsOpen = suggestionListBox.Items.Count > 0;
                query = "AND CongViec.ten_cong_viec = '" + txtSearch.Text + "' ";
            }
            else
            {
                suggestionPopup.IsOpen = false;
                query = "";
            }

            load_frame_cong_viec(query);
        }
        private void suggestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionListBox.SelectedItem != null)
            {
                string selectedItem = suggestionListBox.SelectedItem.ToString();
                txtSearch.Text = selectedItem;
                suggestionPopup.IsOpen = false;
            }
        }
        private string BuildQuerySearch()
        {
            string query = "";

            // Kiểm tra xem đã có từ khóa tìm kiếm từ TextBox txtSearch hay không
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchKeyword = txtSearch.Text.ToLower();
                query += string.Format("AND CongViec.ten_cong_viec LIKE '%{0}%' ", searchKeyword);
            }

            // Kiểm tra ComboBox cbViTri
            ComboBox cbViTri = FindName("cbViTri") as ComboBox;
            if (cbViTri != null && cbViTri.SelectedItem != null && cbViTri.SelectedItem.ToString() != "Tất cả")
            {
                string selectedViTri = cbViTri.SelectedItem.ToString();
                query += string.Format("AND CongViec.vi_tri = '{0}'", selectedViTri);
            }

            // Kiểm tra ComboBox cbLuong
            ComboBox cbLuong = FindName("cbLuong") as ComboBox;
            if (cbLuong != null && cbLuong.SelectedItem != null && cbLuong.SelectedItem.ToString() != "Tất cả")
            {
                string selectedLuong = (cbLuong.SelectedItem as ComboBoxItem).Content.ToString();

                // Thêm điều kiện tìm kiếm theo mức lương vào chuỗi truy vấn
                switch (selectedLuong)
                {
                    case "dưới 5 triệu":
                        query += " AND CongViec.luong < 5000000"; // Số tiền 5 triệu
                        break;
                    case "dưới 10 triệu":
                        query += " AND CongViec.luong < 10000000"; // Số tiền 10 triệu
                        break;
                    case "trên 10 triệu":
                        query += " AND CongViec.luong >= 10000000"; // Số tiền 10 triệu
                        break;
                    default:
                        break;
                }
            }
            return query;
        }

        private void cbViTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = BuildQuerySearch();
            load_frame_cong_viec(query);
        }

        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = BuildQuerySearch();
            load_frame_cong_viec(query);
        }
        private void loadViTri()
        {
            HashSet<string> items = new HashSet<string>();
            ComboBox comboBox = FindName("cbViTri") as ComboBox;
            comboBox.Items.Clear();

            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                string query = @"SELECT 
                CongViec.vi_tri 
               FROM CongViec
               LEFT JOIN QuanLiCongViec
               ON CongViec.id_cong_viec = QuanLiCongViec.id_cong_viec
                  AND CongViec.ma_cong_ty = QuanLiCongViec.ma_cong_ty
               WHERE QuanLiCongViec.id_cong_viec IS NULL";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(reader.GetString(0));
                }
                reader.Close();
                foreach (string item in items)
                {
                    comboBox.Items.Insert(0, item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            comboBox.Items.Add("Tất cả");
        }
    }
}
