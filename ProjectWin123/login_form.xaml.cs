using ProjectWin123.CongTy;
using ProjectWin123.UngVien;
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
using System.Windows.Shapes;

namespace ProjectWin123
{
    /// <summary>
    /// Interaction logic for login_form.xaml
    /// </summary>
    public partial class login_form : Window
    {
        SqlConnection sqlCon = null;
        public login_form()
        {
            InitializeComponent();
        }

        private void dang_nhap(object sender, RoutedEventArgs e)
        {
            System.Security.SecureString securePassword = pass.SecurePassword;
            string password;
            // Chuyển đổi SecureString thành String (ví dụ: để hiển thị trong một MessageBox)
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                password = System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
                // Sử dụng giá trị của password ở đây...
            }
            finally
            {
                // Xóa bộ nhớ đã cấp phát cho SecureString
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * from TaiKhoan";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string userName = reader.GetString(0).Trim();
                string passWord = reader.GetString(1).Trim();
                txtSubmit.Text = passWord;
                if (userName == user.Text.Trim() && password.Trim() == passWord)
                {

                    if (reader.IsDBNull(2))
                    {
                        string maNhanVien = reader.GetString(3);
                        menu_form_UV mn_form_UV = new menu_form_UV(maNhanVien);
                        MessageBox.Show("fsdfasf");
                        mn_form_UV.Show();
                    }
                    else
                    {
                        string maCongTy = reader.GetString(2);
                        menu_form_CT mn_form_CT = new menu_form_CT(maCongTy);
                        mn_form_CT.Show();
                    }
                    this.Hide();
                }
            }
            reader.Close();
        }

        private void btnDangKi_UV_Click(object sender, RoutedEventArgs e)
        {
            register_form_UV rf_UV = new register_form_UV();
            this.Hide();
            rf_UV.Show();
        }
        private void btnDangKi_CT_Click(object sender, RoutedEventArgs e)
        {
            register_form_CT rf_CT = new register_form_CT();
            this.Hide();
            rf_CT.Show();
        }
    }
}
