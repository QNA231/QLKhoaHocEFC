using QuanLyKhoaHocEFC.Entities;
using QuanLyKhoaHocEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Services
{
    public class HocVIenServices : IHocVienServices
    {
        private readonly AppDbContext DbContext;

        public HocVIenServices()
        {
            DbContext = new AppDbContext();
        }

        public void ThemHocVien(int KHId)
        {
            KhoaHoc KH = DbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocId == KHId);
            HocVien hv = new HocVien();
            if(KH != null)
            {
                hv.NhapThongTin(KHId);
                DbContext.Add(hv);
                DbContext.SaveChanges();
                Console.WriteLine("Them hoc vien thanh cong");
            }
            else
            {
                Console.WriteLine("Khong ton tai khoa hoc!");
            }
        }

        public void SuaHocVien(int hvId)
        {
            if(DbContext.HocVien.Any(x => x.HocVienId == hvId))
            {
                var Hv = DbContext.HocVien.Find(hvId);
                Console.WriteLine("Nhap ho ten: ");
                Hv.HoTen = Console.ReadLine();
                Console.WriteLine("Nhap ngay sinh: ");
                Hv.NgaySinh = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Nhap que quan: ");
                Hv.QueQuan = Console.ReadLine();
                Console.WriteLine("Nhap dia chi: ");
                Hv.DiaChi = Console.ReadLine();
                Console.WriteLine("Nhap so dien thoai: ");
                Hv.SoDienThoai = Console.ReadLine();
                DbContext.Update(Hv);
                DbContext.SaveChanges();
                Console.WriteLine("Sua thong tin hoc vien thanh cong!");
            }
            else
            {
                Console.WriteLine("Hoc vien khong ton tai!");
            }
        }

        public List<HocVien> TimKiem(string tenHv, string tenKh)
        {
            var tenCanTim = DbContext.HocVien
                .Join(DbContext.KhoaHoc, x => x.KhoaHocId, y => y.KhoaHocId, (x, y) => new { HocVien = x, KhoaHoc = y })
                .Where(x => x.HocVien.HoTen.ToLower().Contains(tenHv) && x.KhoaHoc.TenKhoaHoc.ToLower().Contains(tenKh))
                .Select(x => new HocVien
                {
                    HocVienId = x.HocVien.HocVienId,
                    HoTen = x.HocVien.HoTen
                })
                .ToList();
            return tenCanTim;
        }
    }
}
