using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dto.Ticket
{
    public class TicketBookDto
    {
        public long Id { get; set; }
        public string DoiTac { get; set; }
        public string MaDonHang { get; set; }
        public string SanphamDichvu { get; set; }
        public double Tongtien { get; set; }
        public string Ngaydathang { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public string TongNguoiLons { get; set; }
        public string TongTreEms { get; set; }
        public string? LoaiThanhToan { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
