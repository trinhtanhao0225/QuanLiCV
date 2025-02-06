using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWin123.ViewModels;
namespace ProjectWin123.ViewModels
{
    
    internal class UngVienDAO
    {
        DBConnnection dbconnnection=new DBConnnection();
        public void capNhatUngVien(ViewModels.UngVien UngVien)
        {
            string query = "UPDATE UngVien SET ten_ung_vien = '" + UngVien.TenUngVien + "', nghe_nghiep = '" + UngVien.NgheNghiep + "', ngay_sinh = '" + UngVien.NgaySinh.ToString() + "', gioi_tinh = '" + UngVien.GioiTinh.ToString() + "', so_dien_thoai = '" + UngVien.SoDienThoai + "', email = '" + UngVien.Email + "', dia_chi = '" + UngVien.DiaChi + "', tin_hoc = '" + UngVien.TinHoc + "', tieng_anh = '" + UngVien.TiengAnh + "', muc_tieu = '" + UngVien.MucTieu + "', hoc_van = '" + UngVien.HocVan + "', kinh_nghiem ='" + UngVien.KinhNghiem + "', hoat_dong = '" + UngVien.HoatDong + "', chung_chi = '" + UngVien.ChungChi + "', danh_hieu = '" + UngVien.DanhHieu + "', thong_tin_them ='" + UngVien.ThongTinThem + "' WHERE can_cuoc_cong_dan = '" + UngVien.CanCuocCongDan + "'";
            dbconnnection.ThucThi(query);
        }
        public void dangKiCongViec(ViewModels.UngVien UngVien, ViewModels.CongViec CongViec)
        {
            string query = "insert into DangKiCongViec(ma_cong_ty,ma_cong_viec,can_cuoc_cong_dan) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + UngVien.CanCuocCongDan + "')";
            dbconnnection.ThucThi(query);
        }
        public void dangKiUngVien(string taiKhoan,string matKhau,string canCuocCongDan)
        {
            string query = "INSERT INTO TaiKhoan (username, pass, ma_nhan_vien) VALUES ('" + taiKhoan + "','" + matKhau + "','" + canCuocCongDan + "')";
            dbconnnection.ThucThi(query);
            query = "INSERT INTO UngVien(can_cuoc_cong_dan) values('" + canCuocCongDan + "')";
            dbconnnection.ThucThi(query);
        }
        public void xoaKetQuaPhongVan(ViewModels.CongViec CongViec,ViewModels.UngVien UngVien)
        {
            string query = "delete  from KetQuaXinViec where ma_cong_ty='" + CongViec.MaCongTy + "' and id_cong_viec='" + CongViec.IdCongViec + "' and can_cuoc_cong_dan='" + UngVien.CanCuocCongDan + "'";
            dbconnnection.ThucThi(query);
        }
    }
}
