using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
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
using Microsoft.Win32;
using ProjectWin123.ViewModels;
namespace ProjectWin123.CongTy
{
    /// <summary>
    /// Interaction logic for register_form_CT.xaml
    /// </summary>
    public partial class register_form_CT : Window
    {
        SqlConnection sqlCon = null;
        ViewModels.CongTy congty = null;
        CongTyDAO CongTyDAO=new CongTyDAO();
        public register_form_CT()
        {
            InitializeComponent();
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
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string destinationFolder = System.IO.Path.Combine(currentDirectory, "image");

            congty = new ViewModels.CongTy(txtTenCongTy.Text, txtMaCongTy.Text, txtLinhVuc.Text, destinationFolder+ "\\" + txtGiayPhep.Content.ToString(), txtDiaChi.Text, txtTenNguoiDungDau.Text, txtCanCuocCongDan.Text, txtSoDienThoai.Text, txtMaSoThue.Text, destinationFolder+"\\" + txtAnhCongTy.Content.ToString(), txtMoTa.Text);
            CongTyDAO.taoTaiKhoan(txtTaiKhoan.Text, password, congty);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            login_form login_Form = new login_form();
            login_Form.Show();
        }
        private void addDuLieu(string query)
        {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(Properties.Settings.Default.connStr);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string insertQuery = query;
                SqlCommand sqlCmd = new SqlCommand(insertQuery, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

            int kq = sqlCmd.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
                sqlCon.Close();

        }

        private void txtGiayPhep_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(sourceFile);

                // Lưu ảnh vào thư mục 'image' trong thư mục hiện tại của ứng dụng
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string destinationFolder = System.IO.Path.Combine(currentDirectory, "image");
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                string destinationFile = System.IO.Path.Combine(destinationFolder, fileName);
                File.Copy(sourceFile, destinationFile, true);
                txtGiayPhep.Content = System.IO.Path.GetFileName(destinationFile);
            }
        }

        private void txtAnhCongTy_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(sourceFile);

                // Lưu ảnh vào thư mục 'image' trong thư mục hiện tại của ứng dụng
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string destinationFolder = System.IO.Path.Combine(currentDirectory, "image");
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                string destinationFile = System.IO.Path.Combine(destinationFolder, fileName);
                File.Copy(sourceFile, destinationFile, true);
                txtAnhCongTy.Content = System.IO.Path.GetFileName(destinationFile);
            }
        }
    }
        
}
