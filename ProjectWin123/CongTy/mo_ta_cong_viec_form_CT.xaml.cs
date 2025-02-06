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
    /// Interaction logic for mo_ta_cong_viec_form_CT.xaml
    /// </summary>
    public partial class mo_ta_cong_viec_form_CT : Window
    {
        ViewModels.CongViec CongViec = null;
        SqlConnection sqlCon = null;
        CongViecDAO congViecDAO = new CongViecDAO();
        List<string> imagePaths = new List<string>(); // Danh sách các đường dẫn ảnh
        int currentImageIndex = 0; // Chỉ số của ảnh đang hiển thị


        public mo_ta_cong_viec_form_CT(ViewModels.CongViec congViec)
        {
            InitializeComponent();
            load_du_lieu(congViec);
            LoadImagesFromPathsString(CongViec.AnhCongViec);
        }
        private void load_du_lieu(ViewModels.CongViec congViec)
        {
                CongViec = congViec;
                ten_cong_ty.Text = congViec.IdCongViec;
                ten_cong_viec.Text = congViec.TenCongViec;
                BitmapImage bitmap = new BitmapImage(new Uri(congViec.LogoCongTy));
                img_CT.Source = bitmap;
                vi_tri.Text = congViec.ViTri;
                luong.Text = congViec.Luong.ToString();
                kinh_nghiem.Text = congViec.KinhNghiem;
                ngay_tuyen.Text = congViec.NgayTuyen.ToString();
                ngay_ket_thuc.Text = congViec.NgayKetThuc.ToString();
                mo_ta.Text = congViec.MoTa;
                ki_nang.Text = congViec.KiNang;
                loai_cong_viec.Text = congViec.LoaiCongViec;
                cap_bac.Text = congViec.CapBac;
                hoc_van.Text = congViec.HocVan;
                gioi_tinh.Text = congViec.GioiTinh;
                nganh_nghe.Text = congViec.NganhNghe;
                ten_lien_he.Text = congViec.TenLienHe;
                vi_tri_cu_the.Text = congViec.ViTriCuThe;
                mo_ta_cong_ty.Text = congViec.VeCongTy;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            congViecDAO.capNhatCongViec(CongViec);
        }
        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            congViecDAO.xoaCongViec(CongViec);
        }
        private void LoadImagesFromPathsString(string imagePathsString)
        {
            string[] paths = imagePathsString.Split(' ');

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
                ShowImage(imagePaths[currentImageIndex]);
            }
        }
        private void Button_NextImage(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++; // Tăng chỉ số hiện tại để chuyển đến ảnh tiếp theo
                ShowImage(imagePaths[currentImageIndex]);
            }
        }

        private void ShowImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    anhCongViec.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
            else
            {
                // Nếu không có hình ảnh, có thể ẩn hoặc xóa hình ảnh hiện tại
                anhCongViec.Source = null;
            }
        }

    }
}
