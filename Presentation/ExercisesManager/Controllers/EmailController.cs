using Domain.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ExercisesManager.Controllers
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
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            
        }
        
    }
}
