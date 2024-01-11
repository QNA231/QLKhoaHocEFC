using QuanLyKhoaHocEFC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.IServices
{
    public interface IHocVienServices
    {
        void ThemHocVien(int KHId);
        void SuaHocVien(int hvId);
        List<HocVien> TimKiem(string tenHv, string tenKh);
    }
}
