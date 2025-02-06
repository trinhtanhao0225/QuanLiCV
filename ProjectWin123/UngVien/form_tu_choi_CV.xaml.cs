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
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for form_tu_choi_CV.xaml
    /// </summary>
    public partial class form_tu_choi_CV : Window
    {
        ViewModels.CongViec CongViec;
        ViewModels.UngVien UngVien;
        public form_tu_choi_CV(CongViec congViec, ViewModels.UngVien ungVien)
        {
            InitializeComponent();
            CongViec = congViec;
            UngVien = ungVien;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            txtTenCongTy.Text = CongViec.TenCongTy.Trim();
            txtTenCongViec.Text = CongViec.TenCongViec.Trim();
            txtTenUngVien.Text = UngVien.TenUngVien.Trim();
        }
    }
}
