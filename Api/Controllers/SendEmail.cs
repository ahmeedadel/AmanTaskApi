using Api.DTO;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmail : ControllerBase
    {
        private readonly IEmailService emailService;

        public SendEmail(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public ActionResult sendEmail(EmailDTO emailDto)
        {
            if (!ModelState.IsValid)
                return NotFound();


            emailService.sendEmail(emailDto);
            return Ok();



        }
    }
}
