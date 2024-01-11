using QuanLyKhoaHocEFC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.IServices
{
    public interface IKhoaHocServices
    {
        void ThemKhoaHoc(KhoaHoc kh);
        void XoaKhoaHoc(int KHId);
        double TinhDoanhThu(int month);
    }
}
