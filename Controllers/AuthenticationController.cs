using Consistrack.Interface;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
namespace Consistrack.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {
        private   IAuthenticateServiceRepo _authenticateserviceRepo;
        public AuthenticationController(IAuthenticateServiceRepo authenticateserviceRepo)
        {
            _authenticateserviceRepo=authenticateserviceRepo;
        }
        [HttpPost]
        public IActionResult post([FromBody]UserMaster Models)
        {
            var user=_authenticateserviceRepo.Authenticate(Models.LoginID,Models.Password);
            if (user==null)
            return BadRequest(new {message="UserName or Password incorrect"});
            return Ok(user);
        }

    }
}