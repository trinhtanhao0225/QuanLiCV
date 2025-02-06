using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectWin123.ViewModels
{
    public class CongTy
    {
        private string tenCongTy;
        private string maCongTy;
        private string linhVuc;
        private string giayPhep;
        private string diaChi;
        private string nguoiDungDau;
        private string canCuocCongDan;
        private string soDienThoai;
        private string maSoThue;
        private string anhCongTy;
        private string moTa;
        public CongTy(string tenCongTy, string maCongTy, string linhVuc, string giayPhep, string diaChi, string nguoiDungDau, string canCuocCongDan, string soDienThoai, string maSoThue, string anhCongTy, string moTa) 
        {
            TenCongTy = tenCongTy;
            MaCongTy = maCongTy;
            LinhVuc = linhVuc;
            GiayPhep= giayPhep;
            DiaChi=diaChi;
            NguoiDungDau = nguoiDungDau;
            CanCuocCongDan= canCuocCongDan;
            SoDienThoai = soDienThoai;
            MaSoThue= maSoThue;
            AnhCongTy = anhCongTy;
            MoTa=moTa;
        }
        public string TenCongTy { get => tenCongTy; set => tenCongTy = value; }
        public string MaCongTy { get => maCongTy; set => maCongTy = value; }
        public string LinhVuc { get => linhVuc; set => linhVuc = value; }
        public string GiayPhep { get => giayPhep; set => giayPhep = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NguoiDungDau { get => nguoiDungDau; set => nguoiDungDau = value; }
        public string CanCuocCongDan { get => canCuocCongDan; set => canCuocCongDan = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string MaSoThue { get => maSoThue; set => maSoThue = value; }
        public string AnhCongTy { get => anhCongTy; set => anhCongTy = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
