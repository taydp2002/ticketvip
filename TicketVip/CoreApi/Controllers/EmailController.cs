
using CoreApi.Models;
using CoreApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {

        private readonly ISendMailService _mailService;
        public EmailController(ISendMailService mailService)
        {
            _mailService = mailService;
        }

        //[HttpPost("Send")]
        [HttpGet]
        public async Task<IActionResult> Send()
        {
                       

                MailContent content = new MailContent
                {
                    To = "tiendev88@gmail.com",
                    Subject = "Kiểm tra thử",
                    Body = "<p><strong>Xin chào xuanthulab.net</strong></p>"
                };

                await _mailService.SendMail(content);


            //        const sendgoooglesheet = await fetch("https://script.google.com/macros/s/AKfycbzG0S4P0HHKaXfD-TXvo1iAbppQwT8FSn0sWT_JnFVi60ZQVJkB9uI3l4YY3u30Hp--3g/exec", {
            //        method: 'POST',
            //    headers:
            //            {
            //                'Content-Type': 'application/json',
            //    },
            //    body: "name=tien&phone=0944838788",
            //});
            //        const resultsend = await sendgoooglesheet.json();
            //        console.log(serialize(formData));
            //        console.log(resultsend);
            using (var client = new HttpClient())
            {
                var content1 = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("name", "tiend"),
                  new KeyValuePair<string, string>("phone", "09448387"),
                    new KeyValuePair<string, string>("email", "tiendev88@gmail.com"),
            });

                var result = await client.PostAsync("https://script.google.com/macros/s/AKfycbzG0S4P0HHKaXfD-TXvo1iAbppQwT8FSn0sWT_JnFVi60ZQVJkB9uI3l4YY3u30Hp--3g/exec", content1);
                string resultContent = await result.Content.ReadAsStringAsync();
                //  Console.WriteLine(resultContent);
            }

            return Ok("Send mail");
           

        }
       


    }
}
