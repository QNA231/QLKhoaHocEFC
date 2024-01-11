using QuanLyKhoaHocEFC.Entities;
using QuanLyKhoaHocEFC.IServices;
using QuanLyKhoaHocEFC.Services;

static void Main()
{
    Console.InputEncoding = System.Text.Encoding.UTF8;
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    IKhoaHocServices khoaHocServices = new KhoaHocServices();
    IHocVienServices hocVienServices = new HocVIenServices();
    INgayHocServices ngayHocServices = new NgayHocServices();

    Console.Clear();
    Console.WriteLine("------------Quan ly khoa hoc------------");
    Console.WriteLine("1. Them khoa hoc");
    Console.WriteLine("2. Them ngay hoc");
    Console.WriteLine("3. Them hoc vien");
    Console.WriteLine("4. Sua thong tin hoc vien");
    Console.WriteLine("5. Xoa khoa hoc");
    Console.WriteLine("6. Tim kiem hoc vien theo ten va khoa hoc");
    Console.WriteLine("7. Tinh doanh thu cua trung tam trong 1 thang");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("Chon: ");
    string s = Console.ReadLine();
    switch (s)
    {
        case "1":
            KhoaHoc kh = new KhoaHoc();
            khoaHocServices.ThemKhoaHoc(kh);
            break;
        case "2":
            Console.WriteLine("Nhap Id khoa hoc can them ngay hoc: ");
            int KHId = int.Parse(Console.ReadLine());
            ngayHocServices.ThemNgayHoc(KHId);
            break;
        case "3":
            Console.WriteLine("Nhap Id khoa hoc can them hoc vien: ");
            int kHId = int.Parse(Console.ReadLine());
            hocVienServices.ThemHocVien(kHId);
            break;
        case "4":
            Console.WriteLine("Nhap Id hoc vien can sua: ");
            int hvId = int.Parse(Console.ReadLine());
            hocVienServices.SuaHocVien(hvId);
            break;
        case "5":
            Console.WriteLine("Nhap Id khoa hoc can xoa: ");
            int khId = int.Parse(Console.ReadLine());
            khoaHocServices.XoaKhoaHoc(khId);
            break;
        case "6":
            Console.WriteLine("Nhap ten khoa hoc can tim kiem hoc vien: ");
            string tenKH = Console.ReadLine();
            Console.WriteLine("Nhap ten hoc vien can tim kiem: ");
            string tenHV = Console.ReadLine();
            List<HocVien> lstresult = hocVienServices.TimKiem(tenHV, tenKH);
            foreach (HocVien hocVien in lstresult)
            {
                Console.WriteLine($"ID hoc vien: {hocVien.HocVienId} \nHo ten hoc vien: {hocVien.HoTen}");
            }
            break;
        case "7":
            Console.WriteLine("Nhap ngay thang nam dau tien cua thang can tinh doanh thu: ");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            int month = dt.Month;
            Console.WriteLine(khoaHocServices.TinhDoanhThu(month));
            break;
    }
}
Main();