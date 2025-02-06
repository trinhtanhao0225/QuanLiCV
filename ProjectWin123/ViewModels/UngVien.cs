using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWin123.ViewModels
{
    public class UngVien
    {
        private string tenUngVien;
        private string ngheNghiep;
        private string canCuocCongDan;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string email;
        private string diaChi;
        private int tinHoc;
        private int tiengAnh;
        private string mucTieu;
        private string hocVan;
        private string kinhNghiem;
        private string hoatDong;
        private string chungChi;
        private string danhHieu;
        private string thongTinThem;

        public UngVien(string text1, string text2, DateTime dateTime, string text3, string text4, string text5, string text6, double value1, double value2, string text7, string text8, string text9, string text10, string text11, string text12, string text13)
        {
            Text1 = text1;
            Text2 = text2;
            DateTime = dateTime;
            Text3 = text3;
            Text4 = text4;
            Text5 = text5;
            Text6 = text6;
            Value1 = value1;
            Value2 = value2;
            Text7 = text7;
            Text8 = text8;
            Text9 = text9;
            Text10 = text10;
            Text11 = text11;
            Text12 = text12;
            Text13 = text13;
        }

        public UngVien(string tenUngVien, string ngheNghiep, string canCuocCongDan, DateTime ngaySinh, string gioiTinh, string soDienThoai, string email, string diaChi, int tinHoc, int tiengAnh, string mucTieu, string hocVan, string kinhNghiem, string hoatDong, string chungChi, string danhHieu, string thongTinThem)
        {
            TenUngVien = tenUngVien;
            NgheNghiep = ngheNghiep;
            CanCuocCongDan = canCuocCongDan;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            TinHoc = tinHoc;
            TiengAnh = tiengAnh;
            MucTieu = mucTieu;
            HocVan = hocVan;
            KinhNghiem = kinhNghiem;
            HoatDong = hoatDong;
            ChungChi = chungChi;
            DanhHieu = danhHieu;
            ThongTinThem = thongTinThem;
        }
        public string TenUngVien { get => tenUngVien; set => tenUngVien = value; }
        public string NgheNghiep { get => ngheNghiep;set => ngheNghiep = value;}
        public string CanCuocCongDan { get => canCuocCongDan;set=>canCuocCongDan= value; }
        public DateTime NgaySinh { get => ngaySinh;set=>ngaySinh= value;}
        public string GioiTinh { get => gioiTinh; set=>gioiTinh= value;}   
        public string SoDienThoai { get => soDienThoai; set=> soDienThoai= value;}  
        public string Email { get => email; set=>email= value;}
        public string DiaChi { get=>diaChi; set=>diaChi= value;}
        public int TinHoc { get => tinHoc; set=>tinHoc= value;}
        public int TiengAnh { get => tiengAnh; set=>tiengAnh= value;}
        public string MucTieu { get => mucTieu; set => mucTieu = value; }
        public string HocVan { get => hocVan;set => hocVan = value; }
        public string KinhNghiem { get=> kinhNghiem;set=>kinhNghiem= value;}
        public string HoatDong { get => hoatDong; set=>hoatDong= value; }
        public string ChungChi { get => chungChi; set => chungChi = value; }
        public string DanhHieu { get => danhHieu;set=>danhHieu= value;}
        public string ThongTinThem { get => thongTinThem;set=>thongTinThem= value;}
        public string Text1 { get; }
        public string Text2 { get; }
        public DateTime DateTime { get; }
        public string Text3 { get; }
        public string Text4 { get; }
        public string Text5 { get; }
        public string Text6 { get; }
        public double Value1 { get; }
        public double Value2 { get; }
        public string Text7 { get; }
        public string Text8 { get; }
        public string Text9 { get; }
        public string Text10 { get; }
        public string Text11 { get; }
        public string Text12 { get; }
        public string Text13 { get; }
    }
}
