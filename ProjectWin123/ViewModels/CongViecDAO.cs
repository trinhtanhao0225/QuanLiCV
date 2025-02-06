using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWin123.ViewModels;
namespace ProjectWin123.ViewModels
{
    internal class CongViecDAO
    {
        DBConnnection dbconnnection=new DBConnnection();
        public void capNhatCongViec(ViewModels.CongViec CongViec)
        {
            string query = "update CongViec set ten_cong_viec='" + CongViec.TenCongViec + "', luong='" + CongViec.Luong + "', kinh_nghiem='" + CongViec.KinhNghiem + "', ngay_tuyen='" + CongViec.NgayTuyen + "', ngay_ket_thuc='" + CongViec.NgayKetThuc + "', mo_ta='" + CongViec.MoTa + "', ki_nang='" + CongViec.KiNang + "', loai_cong_viec='" + CongViec.LoaiCongViec + "', cap_bac='" + CongViec.CapBac + "', hoc_van='" + CongViec.HocVan + "', gioi_tinh='" + CongViec.GioiTinh + "', nganh_nghe='" + CongViec.NganhNghe + "', ten_lien_he='" + CongViec.TenLienHe + "', vi_tri_cu_the='" + CongViec.ViTriCuThe + "', ve_cong_ty='" + CongViec.VeCongTy + "' where id_cong_viec='" + CongViec.IdCongViec + "'";
            dbconnnection.ThucThi(query);
        }
        public void xoaCongViec(ViewModels.CongViec CongViec)
        {
           string query="delete from QuanLiCongViec where id_cong_viec='" + CongViec.IdCongViec + "'";
            dbconnnection.ThucThi(query);

            query="delete from DangKiCongViec where ma_cong_viec='" + CongViec.IdCongViec + "'";
            dbconnnection.ThucThi(query);

            query="delete from CongViec where id_cong_viec='" + CongViec.IdCongViec + "'";
            dbconnnection.ThucThi(query);


        }
    }
}
