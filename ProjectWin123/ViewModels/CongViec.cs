using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWin123.ViewModels
{
    public class CongViec
    {
        private string maCongTy;
        private string tenCongty;
        private string logoCongTy;
        private string idCongViec;
        private string tenCongViec;
        private string anhCongViec;
        private string viTri;
        private int luong;
        private string kinhNghiem;
        private DateTime ngayTuyen;
        private DateTime ngayKetThuc;
        private string moTa;
        private string kiNang;
        private string loaiCongViec;
        private string capBac;
        private string hocVan;
        private string gioiTinh;
        private string nganhNghe;
        private string tenLienHe;
        private string viTriCuThe;
        private string veCongTy;

        public CongViec(string maCongTy,string tenCongTy,string logoCongty, string idCongViec, string tenCongViec, string anhCongViec, string viTri, int luong, string kinhNghiem, DateTime ngayTuyen, DateTime ngayKetThuc, string moTa, string kiNang,string loaiCongViec, string capBac, string hocVan, string gioiTinh, string nganhNghe, string tenLienhe, string viTriCuThe, string veCongTy) {
            MaCongTy = maCongTy;
            TenCongTy = tenCongTy;
            LogoCongTy = logoCongty;
            IdCongViec = idCongViec;
            TenCongViec = tenCongViec;
            AnhCongViec= anhCongViec;
            ViTri=viTri;
            Luong = luong;
            KinhNghiem = kinhNghiem;
            NgayTuyen = ngayTuyen;
            NgayKetThuc = ngayKetThuc;
            MoTa = moTa;
            KiNang = kiNang;
            LoaiCongViec = loaiCongViec;
            CapBac = capBac;
            HocVan = hocVan;
            GioiTinh=gioiTinh;
            NganhNghe = nganhNghe;
            TenLienHe = tenLienhe;
            ViTriCuThe = viTriCuThe;
            VeCongTy = veCongTy;
        }
        public string MaCongTy { get=>maCongTy; set=>maCongTy=value; }
        public string IdCongViec { get => idCongViec; set => idCongViec = value; }
        public string TenCongViec { get => tenCongViec; set => tenCongViec = value; }
        public string AnhCongViec { get => anhCongViec; set => anhCongViec = value; }
        public string ViTri { get => viTri; set => viTri = value; }
        public int Luong { get => luong; set => luong = value; }
        public string KinhNghiem { get => kinhNghiem; set => kinhNghiem = value; }
        public DateTime NgayTuyen { get => ngayTuyen; set => ngayTuyen = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string KiNang { get => kiNang; set => kiNang = value; }
        public string LoaiCongViec { get => loaiCongViec; set => loaiCongViec = value; }
        public string CapBac { get => capBac; set => capBac = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NganhNghe { get => nganhNghe; set => nganhNghe = value; }
        public string TenLienHe { get => tenLienHe; set => tenLienHe = value; }

        public string ViTriCuThe { get => viTriCuThe; set => viTriCuThe = value; }
        public string VeCongTy { get => veCongTy; set => veCongTy = value; }

        public string TenCongTy { get => tenCongty; set => tenCongty = value; }
        public string LogoCongTy { get => logoCongTy; set => logoCongTy = value; }
    }
}
