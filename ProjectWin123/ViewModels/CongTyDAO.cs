using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWin123.ViewModels;
namespace ProjectWin123.ViewModels
{
    internal class CongTyDAO
    {
        DBConnnection dbconnection = new DBConnnection();
        public void capNhatCVYeuThich(ViewModels.CongViec CongViec, ViewModels.UngVien UngVien)
        {
            string query = "insert into CV_YeuThich (ma_cong_ty,can_cuoc_cong_dan) values('" + CongViec.MaCongTy + "','" + UngVien.CanCuocCongDan + "')";
            dbconnection.ThucThi(query);
        }
        public void xetDuyetPhongVan(ViewModels.CongViec CongViec, string CanCuocCongDan, string ngayPhongVan, string thoigianPhongVan)
        {
            string query = "insert into PhongVan (ma_cong_ty,ma_cong_viec,can_cuoc_cong_dan,thoi_gian_phong_van,diem_phong_van) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + CanCuocCongDan + "','" + Convert.ToDateTime(ngayPhongVan + " " + thoigianPhongVan) + "','0')";
            dbconnection.ThucThi(query);
            query = "insert into KetQuaXinViec (ma_cong_ty,id_cong_viec,can_cuoc_cong_dan,ket_qua_xin_viec) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + CanCuocCongDan + "','1')";
            dbconnection.ThucThi(query);
            query = "delete from DangKiCongViec  where ma_cong_ty='" + CongViec.MaCongTy + "'and ma_cong_viec='" + CongViec.IdCongViec + "'and can_cuoc_cong_dan='" + CanCuocCongDan + "'";
            dbconnection.ThucThi(query);

        }
        public void taoTaiKhoan(string TaiKhoan, string MatKhau, ViewModels.CongTy congTy)
        {
            string query = "INSERT INTO TaiKhoan (username, pass, ma_cong_ty, ma_nhan_vien) VALUES ('" + TaiKhoan + "','" + MatKhau + "','" + congTy.MaCongTy + "','')";
            dbconnection.ThucThi(query);

            query = "INSERT INTO CongTy (ten_cong_ty, ma_cong_ty, linh_vuc, giay_phep, dia_chi, nguoi_dung_dau, can_cuoc_cong_dan, so_dien_thoai, ma_so_thue, anh_cong_ty, mo_ta) VALUES (N'" + congTy.TenCongTy + "','" + congTy.MaCongTy + "',N'" + congTy.LinhVuc + "','" + congTy.GiayPhep + "',N'" + congTy.DiaChi + "',N'" + congTy.NguoiDungDau + "','" + congTy.CanCuocCongDan + "','" + congTy.SoDienThoai + "','" + congTy.MaSoThue + "','" + congTy.AnhCongTy + "',N'" + congTy.MoTa + "')";
            dbconnection.ThucThi(query);

        }
        public void capNhatPhongvan(int diemSo,string thoigianPhongVan,ViewModels.CongTy CongTy)
        {
            string query = "update PhongVan set diem_phong_van='" + diemSo + "' where ma_cong_ty='" + CongTy.MaCongTy + "' and thoi_gian_phong_van='" +Convert.ToDateTime(thoigianPhongVan) + "'";
            dbconnection.ThucThi(query);
        }
        public void xoaUngVien(ViewModels.CongViec CongViec,string canCuocCongDan)
        {
            string query = "insert into  KetQuaXinViec (ma_cong_ty,id_cong_viec,can_cuoc_cong_dan,ket_qua_xin_viec,diem_phong_van) values('" + CongViec.MaCongTy + "','" + CongViec.IdCongViec + "','" + canCuocCongDan + "','0')";

        }
    }

}