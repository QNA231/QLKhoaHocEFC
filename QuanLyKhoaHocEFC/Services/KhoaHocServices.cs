using QuanLyKhoaHocEFC.Entities;
using QuanLyKhoaHocEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Services
{
    public class KhoaHocServices : IKhoaHocServices
    {
        private readonly AppDbContext DbContext;

        public KhoaHocServices()
        {
            DbContext = new AppDbContext();
        }

        public void ThemKhoaHoc(KhoaHoc kh)
        {
            Console.WriteLine("Hoc phi phai nho hon 10tr");
            do
            {
                kh.NhapThongTin();
            } while (kh.HocPhi > 10000000);
            DbContext.Add(kh);
            DbContext.SaveChanges();
            Console.WriteLine("Them khoa hoc thanh cong!");
        }

        public void XoaKhoaHoc(int KHId)
        {
            if(DbContext.KhoaHoc.Any(x => x.KhoaHocId == KHId))
            {
                var KH = DbContext.KhoaHoc.Find(KHId);
                var NH = DbContext.NgayHoc.Find(KHId);
                var HV = DbContext.HocVien.Find(KHId);
                if(NH != null)
                {
                    DbContext.Remove(NH);
                    DbContext.Remove(KH);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xoa khoa hoc thanh cong");
                }
                if(HV != null)
                {
                    DbContext.Remove(HV);
                    DbContext.Remove(KH);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xoa khoa hoc thanh cong");
                }
                else
                {
                    DbContext.Remove(KH);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xoa khoa hoc thanh cong");
                }
            }
            else
            {
                Console.WriteLine("Khoa hoc khong ton tai!");
            }
        }
        private int DemSoHocVienCoCungThangBatDau(string tenKhoaHoc)
        {
            var soHocVien = DbContext.HocVien
                .Join(DbContext.KhoaHoc, x => x.KhoaHocId, y => y.KhoaHocId, (x, y) => new { HocVien = x, KhoaHoc = y })
                .Where(x => x.HocVien.KhoaHoc.TenKhoaHoc == tenKhoaHoc)
                .Count();
            return soHocVien;
        }
        public double TinhDoanhThu(int month)
        {
            double totalDoanhThu = 0;
            var khoaHocTrongThang = DbContext.KhoaHoc.Where(x => x.NgayBatDau.Month == month);
            foreach(var kh in khoaHocTrongThang)
            {
                var ten = kh.TenKhoaHoc;
                totalDoanhThu += kh.HocPhi * DemSoHocVienCoCungThangBatDau(ten);
            }
            return totalDoanhThu;
        }
    }
}
