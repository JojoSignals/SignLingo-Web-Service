using Domain.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Shared.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        
        // POST api/<EmailController>
        [HttpPost("email-post")]
        public async Task<IActionResult> SendEmailAsync(string receptor, string subject, string body)
        {
            //var email = CreateEmailFromResourceAssembler.ToEntityFromResource(emailResource);
            await _emailSender.SendEmailAsync(receptor, subject, body);
            
            return Ok();
        }
        
        
    }
}
