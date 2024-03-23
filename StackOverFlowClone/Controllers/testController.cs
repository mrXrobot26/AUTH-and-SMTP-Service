using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverFlowClone.Email;
using StackOverFlowClone.Service.Email;

namespace StackOverFlowClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IEmailService emailService;
        public testController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                Mailrequest mailrequest = new Mailrequest();
                mailrequest.ToEmail = "zezoelbessa10@gmail.com";
                mailrequest.Subject = "Welcome to Bessa";
                mailrequest.Body = GetHtmlcontent();
                await emailService.SendEmailAsync(mailrequest);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private string GetHtmlcontent()
        {
            string Response = "<div style=\"width:100%;background-color:lightblue;text-align:center;margin:10px\">";
            Response += "<h1>Welcome to Bessa</h1>";
            Response += "<h2>Thanks you</h2>";
            Response += "</div>";
            return Response;
        }
    }
}
