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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectWin123.ViewModels;
using System.Data.SqlTypes;
using System.Windows.Automation.Peers;
namespace ProjectWin123.CongTy
{
    public partial class UC_danh_sach_CV_yeu_thich : UserControl
    {
        SqlConnection sqlCon = null;
        ViewModels.CongTy CongTy = null;
        public UC_danh_sach_CV_yeu_thich(ViewModels.CongTy congTy)
        {
            InitializeComponent();
            CongTy = congTy;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            WrapPanel wrapPanel_main = this.FindName("frame_ds_yeu_thich") as WrapPanel;

            if (wrapPanel_main != null)
            {
                wrapPanel_main.Children.Clear();
                try
                {
                    string query = "SELECT * from UngVien right join CV_YeuThich ON  UngVien.can_cuoc_cong_dan=CV_YeuThich.can_cuoc_cong_dan where ma_cong_ty='" + CongTy.MaCongTy + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string tenUngVien = reader.GetString(0);
                        string ngheNghiep = reader.GetString(1);
                        string canCuocCongDan = reader.GetString(2);
                        DateTime ngaySinh = reader.GetDateTime(3);
                        string gioiTinh = reader.GetString(4);
                        string soDienThoai = reader.GetString(5);
                        string email = reader.GetString(6);
                        string diaChi = reader.GetString(7);
                        int tinHoc = reader.GetInt32(8);
                        int tiengAnh = reader.GetInt32(9);
                        string mucTieu = reader.GetString(10);
                        string hocVan = reader.GetString(11);
                        string kinhNghiem = reader.GetString(12);
                        string hoatDong = reader.GetString(13);
                        string chungChi = reader.GetString(14);
                        string danhHieu = reader.GetString(15);
                        string thongTinKhac = reader.GetString(16);
                        ViewModels.UngVien ungVien = new ViewModels.UngVien(tenUngVien, ngheNghiep, canCuocCongDan, ngaySinh, gioiTinh, soDienThoai, email, diaChi, tinHoc, tiengAnh, mucTieu, hocVan, kinhNghiem, hoatDong, chungChi, danhHieu, thongTinKhac);

                        UC_card_CV newCard = new UC_card_CV(ungVien);
                        newCard.Width = 200;
                        newCard.Height = 230;
                        newCard.Margin = new Thickness(0, 0, 10, 10);
                        wrapPanel_main.Children.Add(newCard);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
