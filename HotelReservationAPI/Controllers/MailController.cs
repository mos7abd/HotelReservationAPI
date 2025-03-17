using HotelReservationAPI.Models;
using HotelReservationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MailController : ControllerBase
    {
        public readonly EmailService _emailService;
        public MailController(EmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(MailData mailData)
        {
            if (_emailService.SendEmail(mailData))
            {
                return Ok("Email Sent Successfully");
            }
            else
            {
                return BadRequest("Email Sending Failed");
            }
        }
    }
}
