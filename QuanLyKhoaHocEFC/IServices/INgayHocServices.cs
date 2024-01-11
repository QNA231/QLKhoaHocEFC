using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHocEFC.IServices
{
    public interface INgayHocServices
    {
        void ThemNgayHoc(int KHId);
        void XoaNgayHoc(int KHId, int NHId);
    }
}
