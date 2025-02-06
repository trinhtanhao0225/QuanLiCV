using ProjectWin123.ViewModels;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
namespace ProjectWin123.UngVien
{
    /// <summary>
    /// Interaction logic for register_form_UV.xaml
    /// </summary>
    public partial class register_form_UV : Window
    {
        SqlConnection sqlCon = null;
        UngVienDAO ungVienDAO = new UngVienDAO();
        public register_form_UV()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            login_form login_Form = new login_form();
            login_Form.Show();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            System.Security.SecureString securePassword = txtMatKhau.SecurePassword;
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
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

            ungVienDAO.dangKiUngVien(txtTaiKhoan.Text, password, txtCanCuocCongDan.Text);
            MessageBox.Show("Tạo tài khoản thành công vui lòng đăng nhập và viết CV");
        }
    }
}
