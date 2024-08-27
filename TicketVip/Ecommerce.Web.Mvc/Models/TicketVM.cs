using Ecommerce.Application.Models;
using PayPal.Api;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Web.Mvc.Models
{
    public class TicketVM
    {
        public string doitac { get; set; }//username
        public string madonhang { get; set; }
        public string sanphamdichvu { get; set; }
        public double tongtien { get; set; }
        public string ngaydathang { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string note { get; set; }     
        public int status { get; set; }//da thanh toan
        public TicketType? TongNguoiLons { get; set; }
        public TicketType? TongTreEms { get; set; }
        public string LoaiThanhToan { get; set; }

    }
}
