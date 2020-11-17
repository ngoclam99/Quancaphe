using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class NhanVien
    {
        public string IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public DateTime NgayNghiLam { get; set; }
        public int bTrangthai { get; set; }
    }
}
