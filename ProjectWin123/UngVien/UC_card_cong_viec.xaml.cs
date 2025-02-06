using ProjectWin123.CongTy;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for UC_card_cong_viec.xaml
    /// </summary>
    public partial class UC_card_cong_viec : UserControl
    {
        ViewModels.CongViec CongViec = null;
        ViewModels.UngVien UngVien = null;
        public UC_card_cong_viec(ViewModels.CongViec congViec, ViewModels.UngVien ungVien)
        {
            InitializeComponent();
            CongViec = congViec;
            UngVien = ungVien;
            loadDuLieu();

            
        }
        private void loadDuLieu()
        {
            Uri fileUri = new Uri(CongViec.LogoCongTy, UriKind.Absolute);
            BitmapImage bitmap2 = new BitmapImage(fileUri);
            imgCongViec.Source = bitmap2;
            txtTenCongViec.Text = CongViec.TenCongViec;
            txtViTri.Text = CongViec.ViTri;
            txtKinhNghiem.Text = CongViec.KinhNghiem;
            txtLuong.Text = CongViec.Luong.ToString();
            txt_tenCongTy.Text = CongViec.TenCongTy;
        }
        private void btnXemCongTy_Click(object sender, RoutedEventArgs e)
        {

            mo_ta_cong_ty_UV mota_cong_ty_UV = new mo_ta_cong_ty_UV(CongViec);
            mota_cong_ty_UV.Show();

        }
        private void btnXemCongViec_Click(object sender, RoutedEventArgs e)
        {
            mo_ta_cong_viec_form_UV motaForm_UV = new mo_ta_cong_viec_form_UV(CongViec, UngVien);
            motaForm_UV.Show();
        }
        

    }
}
