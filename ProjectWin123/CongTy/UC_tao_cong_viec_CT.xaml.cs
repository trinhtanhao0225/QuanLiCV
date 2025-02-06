using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProjectWin123.CongTy
{
    public partial class UC_tao_cong_viec_CT : UserControl
    {
        private List<string> selectedImagePaths = new List<string>(); // Danh sách các đường dẫn ảnh đã chọn
        private int currentIndex = 0; // Chỉ số của ảnh đang hiển thị

        SqlConnection sqlCon = null;
        ViewModels.CongTy CongTy = null;

        public UC_tao_cong_viec_CT(ViewModels.CongTy congTy)
        {
            InitializeComponent();
            CongTy = congTy;
            txtTenCongTy.Text = CongTy.TenCongTy;
        }

        public List<string> GetSelectedImagePaths()
        {
            return selectedImagePaths;
        }

        private void Button_Click_ChonAnh(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePaths.Clear(); // Xóa danh sách hình ảnh trước đó
                currentIndex = 0; // Thiết lập lại chỉ số hiện tại

                foreach (string sourceFile in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(sourceFile);
                    string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images"); // Thư mục lưu trữ ảnh
                    string destinationFile = Path.Combine(destinationFolder, fileName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    File.Copy(sourceFile, destinationFile, true);
                    selectedImagePaths.Add(destinationFile);
                }

                ShowImage(currentIndex); // Hiển thị ảnh đầu tiên trong danh sách
                UpdateButtonsState(); // Cập nhật trạng thái của nút điều hướng
            }
        }

        private void Button_PreviousImage(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowImage(currentIndex); // Hiển thị ảnh trước đó
                UpdateButtonsState(); // Cập nhật trạng thái của nút điều hướng
            }
        }

        private void Button_NextImage(object sender, RoutedEventArgs e)
        {
            if (currentIndex < selectedImagePaths.Count - 1)
            {
                currentIndex++;
                ShowImage(currentIndex); // Hiển thị ảnh tiếp theo
                UpdateButtonsState(); // Cập nhật trạng thái của nút điều hướng
            }
        }

        private void ShowImage(int index)
        {
            if (index >= 0 && index < selectedImagePaths.Count)
            {
                string imagePath = selectedImagePaths[index];
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
                // Nếu không có hình ảnh hoặc chỉ số không hợp lệ, ẩn hoặc xóa hình ảnh hiện tại
                anhCongTy.Source = null;
            }
        }

        private void UpdateButtonsState()
        {
            btnPrevious.IsEnabled = currentIndex > 0; // Kích hoạt nút trở lại nếu không phải là ảnh đầu tiên
            btnNext.IsEnabled = currentIndex < selectedImagePaths.Count - 1; // Kích hoạt nút tiếp theo nếu không phải là ảnh cuối cùng
        }

        private void Button_Click_XacNhan(object sender, RoutedEventArgs e)
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

                string idCongViec = txtID.Text.Trim();
                string tenCongViec = txtTenDuAn.Text.Trim();
                string viTri = txtViTri.Text.Trim();
                string luong = txtLuong.Text.Trim();
                string kinhNghiem = txtKinhNghiem.Text.Trim();
                string ngayTuyen = txtBatDau.SelectedDate?.ToString() ?? string.Empty;
                string ngayKetThuc = txtKetThuc.SelectedDate?.ToString() ?? string.Empty;
                string moTa = txtMoTa.Text.Trim();
                string yeuCau = txtYeuCau.Text.Trim();
                string loaiCongViec = txtLoaiCongViec.Text.Trim();
                string capBac = txtCapBac.Text.Trim();
                string hocVan = txtHocVan.Text.Trim();
                string gioi = txtGioi.Text.Trim();
                string nganhNghe = txtNganhNghe.Text.Trim();
                string tenLienHe = txtTenLienHe.Text.Trim();
                string viTriCuThe = txtViTriCuThe.Text.Trim();
                string veCongTy = txtVeCongTy.Text.Trim();

                // Check if an image is selected
                if (selectedImagePaths.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một ảnh.");
                    return; // Exit the method without executing the query
                }

                // Convert the list of image paths to a single string
                string imagePathsString = string.Join(",", selectedImagePaths);

                string insertQuery = "INSERT INTO CongViec(ma_cong_ty, ten_cong_ty, logo_cong_ty, id_cong_viec, ten_cong_viec, anh_cong_viec, vi_tri, luong, kinh_nghiem, ngay_tuyen, ngay_ket_thuc, mo_ta, ki_nang, loai_cong_viec, cap_bac, hoc_van, gioi_tinh, nganh_nghe, ten_lien_he, vi_tri_cu_the, ve_cong_ty) " +
                                     "VALUES (@MaCongTy, @TenCongTy,@LogoCongTy, @IdCongViec, @TenCongViec, @Anh, @ViTri, @Luong, @KinhNghiem, @NgayTuyen, @NgayKetThuc, @MoTa, @YeuCau, @LoaiCongViec, @CapBac, @HocVan, @Gioi, @NganhNghe, @TenLienHe, @ViTriCuThe, @VeCongTy)";

                SqlCommand sqlCmd = new SqlCommand(insertQuery, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MaCongTy", CongTy.MaCongTy);
                sqlCmd.Parameters.AddWithValue("@TenCongTy", CongTy.TenCongTy);
                sqlCmd.Parameters.AddWithValue("@LogoCongTy", CongTy.AnhCongTy);
                sqlCmd.Parameters.AddWithValue("@IdCongViec", idCongViec);
                sqlCmd.Parameters.AddWithValue("@TenCongViec", tenCongViec);
                sqlCmd.Parameters.AddWithValue("@Anh", imagePathsString); // Pass the string containing multiple image paths
                sqlCmd.Parameters.AddWithValue("@ViTri", viTri);
                sqlCmd.Parameters.AddWithValue("@Luong", luong);
                sqlCmd.Parameters.AddWithValue("@KinhNghiem", kinhNghiem);
                sqlCmd.Parameters.AddWithValue("@NgayTuyen", ngayTuyen);
                sqlCmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                sqlCmd.Parameters.AddWithValue("@MoTa", moTa);
                sqlCmd.Parameters.AddWithValue("@YeuCau", yeuCau);
                sqlCmd.Parameters.AddWithValue("@LoaiCongViec", loaiCongViec);
                sqlCmd.Parameters.AddWithValue("@CapBac", capBac);
                sqlCmd.Parameters.AddWithValue("@HocVan", hocVan);
                sqlCmd.Parameters.AddWithValue("@Gioi", gioi);
                sqlCmd.Parameters.AddWithValue("@NganhNghe", nganhNghe);
                sqlCmd.Parameters.AddWithValue("@TenLienHe", tenLienHe);
                sqlCmd.Parameters.AddWithValue("@ViTriCuThe", viTriCuThe);
                sqlCmd.Parameters.AddWithValue("@VeCongTy", veCongTy);

                int kq = sqlCmd.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
