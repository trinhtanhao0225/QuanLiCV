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
using ProjectWin123.ViewModels;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for UC_card_CV.xaml
    /// </summary>
    public partial class UC_card_CV : UserControl
    {
        ViewModels.UngVien UngVien = null;
        public UC_card_CV(ViewModels.UngVien ungVien)
        {
            InitializeComponent();
            UngVien = ungVien;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            txtTenFront.Text = txtTenBack.Text = UngVien.TenUngVien;
            txtEmail.Text = UngVien.Email;
            txtCanCuocCongDan.Text = UngVien.CanCuocCongDan;
            txtNgheNghiep.Text = UngVien.NgheNghiep;
            txtSoDienThoai.Text = UngVien.SoDienThoai;
        }

        private void btnCV_Click(object sender, RoutedEventArgs e)
        {
            CV_form_CT cv_form_CT = new CV_form_CT(UngVien.CanCuocCongDan, null);
            cv_form_CT.Show();
        }
    }
}
