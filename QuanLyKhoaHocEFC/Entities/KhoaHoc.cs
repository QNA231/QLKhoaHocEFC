using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.Entities
{
    public class KhoaHoc
    {
        public int KhoaHocId { get; set; }
        [Required]
        [MaxLength(10)]
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        [Required]
        public double HocPhi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc
        {
            get { return NgayBatDau.AddDays(15); }
        }
        public IEnumerable<HocVien> DanhSachHocVien { get; set; }
        public IEnumerable<NgayHoc> DanhSachNgayHoc { get; set; }
        public void NhapThongTin()
        {
            KhoaHocId = 0;
            Console.WriteLine("Nhap ten khoa hoc: ");
            TenKhoaHoc = Console.ReadLine();
            Console.WriteLine("Nhap mo ta: ");
            MoTa = Console.ReadLine();
            Console.WriteLine("Nhap hoc phi: ");
            HocPhi = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ngay bat dau: ");
            NgayBatDau = DateTime.Parse(Console.ReadLine());
        }
    }
}
