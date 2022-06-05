using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Chat.V2;

namespace Twilio_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OTPController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("sendSMS")]
        public IActionResult Get()
        {

            string accountSid = "ACf46c3009c2b81a39276475b4502b26bf";
            string authToken = "edd29a72dd17e5332078fd332b0e2bb9";

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var message = MessageResource.Create(
                    body: "Your OTP is 123456",
                    from: new Twilio.Types.PhoneNumber("+19712571831"),
                    to: new Twilio.Types.PhoneNumber("+919955074864")
                );
                return Ok(message);
            }
            catch (ApiException e)
            {
                return Ok(e.Message);
            }
        } 
    }
}