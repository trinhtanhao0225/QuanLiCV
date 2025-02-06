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
    /// <summary>
    /// Interaction logic for UC_thong_bao_dang_ki_UV.xaml
    /// </summary>
    public partial class UC_thong_bao_dang_ki_UV : UserControl
    {
        ViewModels.CongViec CongViec;
        ViewModels.UngVien UngVien;
        string KetQua;
        SqlConnection sqlCon;
        UngVienDAO ungVienDAO = new UngVienDAO();
        public UC_thong_bao_dang_ki_UV(ViewModels.CongViec congViec, ViewModels.UngVien ungVien, string ketqua)
        {
            InitializeComponent();
            CongViec = congViec;
            UngVien = ungVien;
            KetQua=ketqua;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            if (KetQua == "0")
            {
                txtThongBao.Text = "Bạn đã trượt phỏng vấn";
            }
        }

        private void btnThongTinThem_Click(object sender, RoutedEventArgs e)
        {
            if (KetQua == "1")
            {
                form_tham_gia_phong_van_UV form_Tham_Gia_Phong_Van_UV = new form_tham_gia_phong_van_UV(CongViec, UngVien);
                form_Tham_Gia_Phong_Van_UV.Show();
            }
            else
            {
                form_tu_choi_CV form_Tu_Choi_CV = new form_tu_choi_CV(CongViec, UngVien);
                form_Tu_Choi_CV.Show();
            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            ungVienDAO.xoaKetQuaPhongVan(CongViec, UngVien);
        }
    }
}
