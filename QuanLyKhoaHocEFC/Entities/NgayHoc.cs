using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Entities
{
    public class NgayHoc
    {
        public int NgayHocId { get; set; }
        public int KhoaHocId { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public void NhapThongTin(int KHId)
        {
            NgayHocId = 0;
            KhoaHocId = KHId;
            Console.WriteLine("Nhap noi dung: ");
            NoiDung = Console.ReadLine();
            Console.WriteLine("Nhap ghi chu: ");
            GhiChu = Console.ReadLine();
        }
    }
}
