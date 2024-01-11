using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Entities
{
    public class HocVien
    {
        public int HocVienId { get; set; }
        public int KhoaHocId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public void NhapThongTin(int KHId)
        {
            HocVienId = 0;
            KhoaHocId = KHId;
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh: ");
            NgaySinh = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap que quan: ");
            QueQuan = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
            Console.WriteLine("Nhap so dien thoai: ");
            SoDienThoai = Console.ReadLine();
        }
    }
}
