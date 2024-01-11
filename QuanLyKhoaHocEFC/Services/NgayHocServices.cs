using QuanLyKhoaHocEFC.Entities;
using QuanLyKhoaHocEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Services
{
    public class NgayHocServices : INgayHocServices
    {
        private readonly AppDbContext DbContext;

        public NgayHocServices()
        {
            DbContext = new AppDbContext();
        }
        private int DemSoNgayHoc(int KhId)
        {
            var soNgayHoc = DbContext.NgayHoc.Where(x => x.KhoaHocId == KhId).Count();
            return soNgayHoc;
        }

        public void ThemNgayHoc(int KHId)
        {
            KhoaHoc kh = DbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocId == KHId);
            NgayHoc nh = new NgayHoc();
            if(kh != null)
            {
                DateTime currentDate = new DateTime(2024, 1, 2);
                DateTime startDate = kh.NgayBatDau;
                int soNgayHoc = DemSoNgayHoc(kh.KhoaHocId);
                DateTime endDate = startDate.AddDays(1);
                if(currentDate <= endDate && soNgayHoc < 15)
                {
                    nh.NhapThongTin(kh.KhoaHocId);
                    DbContext.Add(nh);
                    DbContext.SaveChanges();
                    Console.WriteLine("Them ngay hoc thanh cong");
                }
                else
                {
                    Console.WriteLine("Khoa hoc da het han!");
                }
            }
            else
            {
                Console.WriteLine("Khoa hoc khong ton tai!");
            }
        }

        public void XoaNgayHoc(int KHId, int NHId)
        {
            KhoaHoc kh = DbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocId == KHId);
            if(kh != null)
            {
                if(DbContext.NgayHoc.Any(x => x.NgayHocId == NHId))
                {
                    var nh = DbContext.NgayHoc.Find(NHId);
                    DbContext.Remove(nh);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xoa ngay hoc thanh cong!");
                }
                else
                {
                    Console.WriteLine("Khoa hoc chua co ngay hoc");
                }
            }
            else
            {
                Console.WriteLine("Khong ton tai khoa hoc!");
            }
        }
    }
}
