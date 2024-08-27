using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Ecommerce.Web.Mvc.Models;
using Newtonsoft.Json;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Web.Helpers;
using System.Text.Json;
using Ecommerce.Application.Handlers.TicketBooking.Commands;
using MediatR;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Application.Extension;
using Ecommerce.Web.Mvc.Extension;
using System.Security.Claims;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Ecommerce.Application.Handlers.TicketBooking.Queries;
using Ecommerce.Web.Mvc.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Handlers.PortfolioCategory.Queries;
using Ecommerce.Application.Models;
using Newtonsoft.Json;
using Ecommerce.Application.Handlers.PortfolioCategory.Commands;
using SelectPdf;
using System.Globalization;
using CoreHtmlToImage;
using System.Text;

namespace Ecommerce.Web.Mvc.Controllers
{
    [Authorize]
    public class QRController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public QRController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        [Authorize]
        public IActionResult Use()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> RenderView1()
        {
            string user = User.Identity.Name;
            int type = 0;//admin
            if (User.IsInRole("DoiTac"))
            {
                type = 1;
            }
            if (User.IsInRole("BanHang"))
            {
                type = 2;
            }
            if (User.IsInRole("Admin"))
            {
                type = 0;
            }

            var paging = new PageRequest().GetPageResponse(Request);

            var result = await _mediator.Send(new GetTicketWithPagingQuery { page = paging.PageIndex, length = 100, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder, UserName = user, Type = type,Status=2});

            var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
            var j = Json(jsonData);
            return Json(jsonData);
        }
        [Authorize]
        public IActionResult UnUse()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> RenderView2()
        {
            string user = User.Identity.Name;
            int type = 0;//admin
            if (User.IsInRole("DoiTac"))
            {
                type = 1;
            }
            if (User.IsInRole("BanHang"))
            {
                type = 2;
            }
            if (User.IsInRole("Admin"))
            {
                type = 0;
            }

            var paging = new PageRequest().GetPageResponse(Request);

            var result = await _mediator.Send(new GetTicketWithPagingQuery { page = paging.PageIndex, length = 100, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder, UserName = user, Type = type, Status =1 });

            var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
            var j = Json(jsonData);
            return Json(jsonData);
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string user = User.Identity.Name;
            int type = 0;//admin
            if (User.IsInRole("DoiTac"))
            {
                type = 1;
            }
            if (User.IsInRole("BanHang"))
            {
                type = 2;
            }
            if (User.IsInRole("Admin"))
            {
                type = 0;
            }
            var total = await _mediator.Send(new GetTicketTotalQuery { User = user,Type= type });
           
            ViewBag.Total = total.Total.ToString("#,###", cul.NumberFormat); ;
            
            ViewBag.Count = total.TongVe.ToString("#,###", cul.NumberFormat); ;
            
            return View();
        }
        [Authorize]
        public async Task<IActionResult> RenderView()
        {
            string user = User.Identity.Name;
            int type = 0;//admin
            if (User.IsInRole("DoiTac"))
            {
                type = 1;
            }
            if (User.IsInRole("BanHang"))
            {
                type =2;
            }
            if (User.IsInRole("Admin"))
            {
                type = 0;
            }

            var paging = new PageRequest().GetPageResponse(Request);

            var result = await _mediator.Send(new GetTicketWithPagingQuery { page = paging.PageIndex, length = 100, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder, UserName= user, Type=type,Status=0});

            var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
           var j= Json(jsonData);
            return Json(jsonData);
        }
        [HttpPost]
        public async Task<IActionResult> TicketConform(CreateTicketBookingCommand command)
        {

            command.Status = 1;
            int view = 1;
            //chekc madon hang khong trung
            //tìm có vé theo đơn hàng này chưa
            var ticket = await _mediator.Send(new GetTicketByMaDonHangQuery() { MaDonHang = command.MaDonHang });
            if (ticket != null)
            {
                return RedirectToAction("Error");
            }
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(command);
                if (response.Succeeded) return RedirectToAction("Success");
                ModelState.AddModelError(string.Empty, response.Message);
            }

            return RedirectToAction("Success", 1);

            //    return View(command);
        }
        [AllowAnonymous]
        public async Task<IActionResult> TicketCheck(string data)
        {
            var command = new CreateTicketBookingCommand();


            ViewBag.Login = 0;
            var tk = JsonConvert.DeserializeObject<TicketVM>(data);

            //tìm có vé theo đơn hàng này chưa
            var ticket = await _mediator.Send(new GetTicketByMaDonHangQuery() { MaDonHang = tk.madonhang });

            if (ticket == null)
            {
                command.Status = 0;
                ViewBag.Status = 0;
            }
            else
            {
                if (ticket.Status == 2)
                {
                    command.Status = 2;
                    command.Id = ticket.Id;
                }
                else
                {
                    command.Status = 1;
                    command.Id = ticket.Id;
                }

            }

            if (!User.Identity.IsAuthenticated)
            {
                //chua login
                //chỉ show thông tin vé và trạng thái chưa thanh toán
                command.UserName = tk.name;
            }
            else
            {
                ViewBag.Login = 1;
                command.UserName = User.Identity.Name;

                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var role = await _userService.ManageRolesAsync(user);

                if (role.Succeeded)
                {
                    foreach (var item in role.Data.ManageRolesDto)
                    {
                        if (item.Name == "Admin" && item.Checked == true)
                        {
                            //ViewBag.Status = 1;
                            ViewBag.Login = 2;
                            break;
                        }
                        if (item.Name == "Basic" && item.Checked == true)
                        {
                            //ViewBag.Status = 1;
                            ViewBag.Login = 2;
                            break;
                        }

                    }
                }
            }

            command.Phone = tk.phone;
            command.Email = tk.email;
            command.Name = tk.name;
            command.Address = tk.address;
            command.SanphamDichvu = tk.sanphamdichvu;
            command.Note = tk.note;
            command.DoiTac = tk.doitac;
            command.MaDonHang = tk.madonhang;
            command.Tongtien = tk.tongtien;
            command.Ngaydathang = tk.ngaydathang;
            command.TongNguoiLon = JsonConvert.DeserializeObject<TicketType>(ticket.TongNguoiLons);
            command.TongTreEm = JsonConvert.DeserializeObject<TicketType>(ticket.TongTreEms);
          
            return View(command);
        }


        [HttpPost]

        public async Task<IActionResult> TicketCheck(UpdateTicketBookingCommand command)
        {
            var user = User.Identity.Name;
            var ticket = await _mediator.Send(new GetTicketByIdQuery() { Id = command.Id });
            if (ticket != null && ticket.DoiTac == user)
            {
                //làm save database
                //Gửi email đối tác và admin và khách hàng

                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(new UpdateTicketBookingCommand() { Id = command.Id, UserName = user });
                    if (response.Succeeded) return RedirectToAction("Success");
                    ModelState.AddModelError(string.Empty, response.Message);
                }

                return RedirectToAction("Success");

            }
            else
            {
                return RedirectToAction("Error");
            }


        }
        public IActionResult Success()
        {

            return View();
        }
        public IActionResult Error()
        {

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "BanHang")]
      //  [Authorize(Permissions.Permissions_User_View)]
        public async Task<IActionResult> CreateQR()
        {
            var response = await _userService.GetUsersAsync();
            var t = new List<UserDto>();
            foreach (var item in response)
            {
                var role = await _userService.ManageRolesAsync(item.Id);
                foreach (var item1 in role.Data.ManageRolesDto)
                {
                    if (item1.Checked && item1.Name=="DoiTac")
                    {
                        t.Add(item);
                    }

                }

            }
            ViewData["DoiTacList"] = new SelectList(t, "UserName", "UserName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQR(CreateTicketBookingCommand command)
        {
           
            //thêm 2 cột json người lớn, rẻ e,
            if (command.Note == null)
            {
                command.Note = "";

            }
            if (command.Ngaydathang == null)
            {
                command.Ngaydathang = DateTime.Now.ToShortDateString();

            }
            if (command.Address == null)
            {
                command.Address = "";

            }

            command.MaDonHang = "DLRV-" + StringHelper.GetRandomString(8);
            command.Status = 1;
            command.Ngaydathang = DateTime.Now.ToLongDateString();
            //  var command = new CreateTicketBookingCommand();

            command.UserName = User.Identity.Name;

            command.Status = 1;
            //chekc madon hang khong trung
            //tìm có vé theo đơn hàng này chưa
            var ticket = await _mediator.Send(new GetTicketByMaDonHangQuery() { MaDonHang = command.MaDonHang });
            if (ticket != null)
            {
                ModelState.AddModelError(string.Empty, "Lỗi trùng đơn hàng");
                return View(command);
            }

            var response = await _mediator.Send(command);
            if (response.Succeeded)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                //chuyển thành mã QR
                var data = new TicketVM()
                {
                    doitac = command.DoiTac,
                    madonhang = command.MaDonHang,
                    sanphamdichvu = command.SanphamDichvu,
                    ngaydathang = command.Ngaydathang,
                    tongtien = command.Tongtien,
                    name = command.Name,
                    phone = command.Phone,
                    email = command.Email,
                    address = command.Address,
                    note = command.Note,
                    status = command.Status,
                    TongNguoiLons = command.TongNguoiLon,
                    TongTreEms = command.TongTreEm,
                    LoaiThanhToan = command.LoaiThanhToan
                };
                    //var dataString = "{"+"doitac:" + "'"+ +"'"command.DoiTac +
                    //    "madonhang:" + command.MaDonHang +
                    //    "sanphamdichvu:" + command.SanphamDichvu +
                    //    "ngaydathang:" + command.Ngaydathang +
                    //    "tongtien:" + command.Tongtien +
                    //    "name:" + command.Phone +
                    //    "phone:" + command.DoiTac +
                    //    "email:" + command.Email +
                    //    "address:" + command.Address +
                    //    "note:" + command.Note +
                    //      "status:" + command.Status+"}";

                    //var settings = new JsonSerializerSettings { Converters = { new ReplacingStringWritingConverter("\n", "") } };

                    var newJson = JsonConvert.SerializeObject(data, Formatting.None);

                //  string strJson = System.Text.Json.JsonSerializer.Serialize<TicketVM>(data);


                // string google_chart_api_url = "https://chart.googleapis.com/chart?chs=200x200&cht=qr&chl=https://ticketvip.vn/qr/TicketCheck?data=" + newJson + "&choe=UTF-8";

                //  ViewBag.QrCodeUri = google_chart_api_url;
               // string strJson = System.Text.Json.JsonSerializer.Serialize<TicketVM>(data);
                string url = "https://ticketvip.vn/qr/TicketCheck?data=" + newJson;
                QRCodeModel qRCode = new QRCodeModel();
                qRCode.QRCodeText = url;
                QRCodeGenerator QrGenerator = new QRCodeGenerator();
                QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
                QRCode QrCode = new QRCode(QrCodeInfo);
                Bitmap QrBitmap = QrCode.GetGraphic(60);
                byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                ViewBag.QrCodeUri = QrUri;

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string a = double.Parse("12345").ToString("#,###", cul.NumberFormat);
                //in vé
                var html = System.IO.File.ReadAllText(@"wwwroot/t.html", Encoding.UTF8);
                html = html.Replace("{QRCode}", QrUri);
                html = html.Replace("{DoiTac}", command.DoiTac);
                html = html.Replace("{Name}", command.Name);
                html = html.Replace("{Phone}", command.Phone);
                html = html.Replace("{Ngaydathang}", command.Ngaydathang);
                html = html.Replace("{MaDonHang}", command.MaDonHang);
                html = html.Replace("{LoaiThanhToan}", command.LoaiThanhToan);
                html = html.Replace("{SanphamDichvu}", command.SanphamDichvu);
                html = html.Replace("{TongNguoiLon.SoLuong}", command.TongNguoiLon.SoLuong.ToString());
                html = html.Replace("{TongNguoiLon.Tong}", command.TongNguoiLon.Tong.ToString("#,###", cul.NumberFormat));
                html = html.Replace("{TongTreEm.SoLuong}", command.TongTreEm.SoLuong.ToString());
                html = html.Replace("{TongTreEm.Tong}", command.TongTreEm.Tong.ToString("#,###", cul.NumberFormat));
                html = html.Replace("{Tongtien}", command.Tongtien.ToString("#,###", cul.NumberFormat));
                html = html.Replace("{Note}", command.Note);

                HtmlToPdf converter = new HtmlToPdf();
                // create a new pdf document converting an html string
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);
                // convert the url to pdf
                // SelectPdf.PdfDocument doc = converter.ConvertUrl("https://localhost:5059/t.html");

               // PdfPage page = doc.AddPage(PdfCustomPageSize.A5, new PdfMargins(0f), PdfPageOrientation.Portrait);
                
                // save pdf document
                doc.Save(@"wwwroot/" + command.MaDonHang + ".pdf");
               
                // close pdf document
                doc.Close();

                var converter1= new HtmlConverter();
               
                 var bytes = converter1.FromHtmlString(html);
                
                //File.WriteAllBytes("image.jpg", bytes);
                System.IO.File.WriteAllBytes(@"wwwroot/"+command.MaDonHang+ ".jpg", bytes);

                //string pdfFilePath = "wwwroot/ticket.pdf";

                //byte[] bytes1 = System.IO.File.ReadAllBytes(pdfFilePath);

                //// munge bytes with whatever pdf software you want, i.e. http://sourceforge.net/projects/itextsharp/
                //// bytes = MungePdfBytes(bytes); // MungePdfBytes is your custom method to change the PDF data
                //// ...
                //// make sure to cleanup after yourself

                //// and save back - System.IO.File.WriteAll* makes sure all bytes are written properly - this will overwrite the file, if you don't want that, change the path here to something else
                //System.IO.File.WriteAllBytes("wwwroot/ticket.jpg", bytes);



                return View(command);
            }

            //  return RedirectToAction("Success");



            //  return RedirectToAction("Success", 1);

            return View(command);

           
            //return View();
        }

        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQRCode(TicketVM data)
        {
            data.madonhang = "DLRV-" + StringHelper.GetRandomString(8);
            data.status = 1;
            data.ngaydathang = DateTime.Now.ToLongDateString();
            var command = new CreateTicketBookingCommand();

            command.DoiTac = data.doitac;
            command.MaDonHang = data.madonhang;
            command.SanphamDichvu = data.sanphamdichvu;
            command.Tongtien = data.tongtien;
            command.Ngaydathang = data.ngaydathang;
            command.Status = 1;
            command.Phone = data.phone;
            command.Email = data.email;
            command.Name = data.name;
            command.Address = data.address;
            command.Note = data.note;
            command.UserName = User.Identity.Name;


            //chekc madon hang khong trung
            //tìm có vé theo đơn hàng này chưa
            var ticket = await _mediator.Send(new GetTicketByMaDonHangQuery() { MaDonHang = command.MaDonHang });
            if (ticket != null)
            {
                ModelState.AddModelError(string.Empty, "Lỗi trùng đơn hàng");
                return View(data);
            }
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(command);
                if (response.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    //chuyển thành mã QR
                    string strJson = System.Text.Json.JsonSerializer.Serialize<TicketVM>(data);

                    QRCodeModel qRCode = new QRCodeModel();
                    qRCode.QRCodeText = strJson;
                    QRCodeGenerator QrGenerator = new QRCodeGenerator();
                    QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
                    QRCode QrCode = new QRCode(QrCodeInfo);
                    Bitmap QrBitmap = QrCode.GetGraphic(60);
                    byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                    string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                    ViewBag.QrCodeUri = QrUri;

                    return View();

                }
                //  return RedirectToAction("Success");

            }

            //  return RedirectToAction("Success", 1);

            return View(data);
        }

        [HttpPost]
        [Authorize(Permissions.Permissions_QR_Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteTicketCommand { Id = id });
            return Json(response);
        }
    }

}

//Extension method to convert Bitmap to Byte Array
public static class BitmapExtension
{
    public static byte[] BitmapToByteArray(this Bitmap bitmap)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}

