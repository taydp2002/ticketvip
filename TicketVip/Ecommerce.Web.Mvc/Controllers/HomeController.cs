using Ecommerce.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.IO;
using PdfSharpCore.Pdf;
using PdfSharpCore;
using SelectPdf;
using Microsoft.AspNetCore.Html;




namespace Ecommerce.Web.Mvc.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //[ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
    public IActionResult Index()
    {
        //PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Thông tin vé của bạn</h1>This is html rendered text</p>", PageSize.A5);
        //pdf.Save("wwwroot/document.pdf");
        var html = System.IO.File.ReadAllText(@"wwwroot/t.html");
        html = html.Replace("{name}", "Tiêd");
        // return html;

        //PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
        // pdf.Save("wwwroot/document.pdf");

        //// instantiate a html to pdf converter object
        //HtmlToPdf converter = new HtmlToPdf();

        //// create a new pdf document converting an url
        //PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

        //// save pdf document
        //doc.Save(Response, false, "Sample.pdf");

        // close pdf document
        //doc.Close();
        // instantiate the html to pdf converter

        HtmlToPdf converter = new HtmlToPdf();
        // create a new pdf document converting an html string
        SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);
        // convert the url to pdf
       // SelectPdf.PdfDocument doc = converter.ConvertUrl("https://localhost:5059/t.html");

        // save pdf document
        doc.Save("t.pdf");

        // close pdf document
        doc.Close();


        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult ContactUs()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
