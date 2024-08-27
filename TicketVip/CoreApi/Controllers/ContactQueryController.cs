using AutoMapper;
using CoreApi.Models;
using CoreApi.Service;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Handlers.ContactQueries.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactQueryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISendMailService _mailService;

        public ContactQueryController(IMediator mediator, IMapper mapper, ISendMailService mailService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _mailService = mailService;
        }

        [HttpGet]
        //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get(string fullName)
        {
            return Ok("Succeeded");
        }    


        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(ContactQueryDto dto)
        {
            if (dto.MessageBody == null)
            {
                dto.MessageBody = dto.Subject;

            }
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateContactQueryCommand>(dto);
                var response = await _mediator.Send(command);
                if (response.Succeeded)
                {
                    //  TempData["notification"] = "<script>swal(`" + "Success!" + "`, `" + "Your Message Send Successfully! `,`" + "success" + "`)" + "</script>";
                    //return Redirect("/");
                    
                    MailContent content = new MailContent
                    {
                        To = dto.Email,
                        Subject = dto.Subject,
                        Body = "<p><strong>Cảm ơn bạn: "+dto.FullName+" - Phone: "+dto.Phone+" đã phản hồi với chúng tôi</strong></p>" + dto.MessageBody+ "<br/><hr/><p><hr/> Chúng tôi sẽ liên hệ bạn ngay hoặc bạn gọi: 0944838788 để được tư vấn miễn phí </p>" + "<hr/><i>Trân trọng cảm ơn bạn !</>"
                    };
                  
                    await _mailService.SendMail(content);

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

                    return Ok(response.Succeeded);

                }
                // ModelState.AddModelError(string.Empty, response.Message);
            }
            return Ok("Error");
            //return View(dto);
        }
    }
}
