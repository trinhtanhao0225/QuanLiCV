using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for UC_card_cong_viec_CT.xaml
    /// </summary>
    public partial class UC_card_cong_viec_CT : UserControl
    {
        ViewModels.CongViec CongViec = null;
        public event EventHandler<ViewModels.CongViec> CongViecSent;
        public UC_card_cong_viec_CT(ViewModels.CongViec congViec)
        {
            InitializeComponent();
            load_du_lieu(congViec);
            
        }
        private void load_du_lieu(ViewModels.CongViec congViec)
        {
            CongViec = congViec;
            txtLuong.Text = CongViec.Luong.ToString();
            txtKinhNghiem.Text = CongViec.KinhNghiem;
            txtViTri.Text = CongViec.ViTri;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CongViec != null)
            {
                CongViecSent?.Invoke(this, CongViec);
            }
            
        }
    }
}
