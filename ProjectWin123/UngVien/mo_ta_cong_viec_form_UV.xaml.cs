using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProjectWin123.UngVien
{
    public partial class mo_ta_cong_viec_form_UV : Window
    {
        ViewModels.CongViec CongViec = null;
        ViewModels.UngVien UngVien = null;
        SqlConnection sqlCon = null;
        List<string> imagePaths = new List<string>(); // Danh sách các đường dẫn ảnh
        int currentImageIndex = 0; // Chỉ số của ảnh đang hiển thị

        public mo_ta_cong_viec_form_UV(ViewModels.CongViec congViec, ViewModels.UngVien ungVien)
        {
            InitializeComponent();
            UngVien = ungVien;
            CongViec = congViec;
            LoadData();
            LoadImagesFromPathsString(CongViec.AnhCongViec); // Load hình ảnh từ chuỗi đường dẫn
            ShowImage(currentImageIndex); // Hiển thị ảnh đầu tiên
        }

        private void LoadData()
        {
            txtTenCongViec.Text = CongViec.TenCongViec;
            BitmapImage bitmap = new BitmapImage(new Uri(CongViec.LogoCongTy));
            img_CT.Source = bitmap;
            txtViTri.Text = CongViec.ViTri;
            txtLuong.Text = CongViec.Luong.ToString();
            txtKinhNghiem.Text = CongViec.KinhNghiem;
            txtNgayTuyen.Text = CongViec.NgayTuyen.ToString();
            txtNgayketThuc.Text = CongViec.NgayKetThuc.ToString();
            txtMoTa.Text = CongViec.MoTa;
            txtKiNang.Text = CongViec.KiNang;
            txtLoaiCongViec.Text = CongViec.LoaiCongViec;
            txtGioiTinh.Text = CongViec.GioiTinh;
            txtNganhNghe.Text = CongViec.NganhNghe;
            txtTenLienHe.Text = CongViec.TenCongViec;
            txtViTriCuThe.Text = CongViec.ViTriCuThe;
            txtVeCongTy.Text = CongViec.VeCongTy;
        }

        private void LoadImagesFromPathsString(string imagePathsString)
        {
            string[] paths = imagePathsString.Split(',');

            foreach (string path in paths)
            {
                imagePaths.Add(path.Trim());
            }
        }

        private void Button_PreviousImage(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--; // Giảm chỉ số hiện tại để chuyển đến ảnh trước đó
                ShowImage(currentImageIndex);
            }
        }

        private void Button_NextImage(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++; // Tăng chỉ số hiện tại để chuyển đến ảnh tiếp theo
                ShowImage(currentImageIndex);
            }
        }

        private void ShowImage(int index)
        {
            if (index >= 0 && index < imagePaths.Count)
            {
                string imagePath = imagePaths[index];
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    anhCongTy.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
            else
            {
                // Nếu không có hình ảnh, có thể ẩn hoặc xóa hình ảnh hiện tại
                anhCongTy.Source = null;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string query = "insert into DangKiCongViec(ma_cong_ty,ma_cong_viec,can_cuoc_cong_dan) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + UngVien.CanCuocCongDan + "')";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Nộp đơn thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được chèn.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
