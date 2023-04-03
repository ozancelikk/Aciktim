using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ICustomerAuthService _customerAuthService;
        public AuthController(ICustomerAuthService customerAuthService)
        {
            _customerAuthService = customerAuthService;
        }
        [HttpPost("Register")]
        public IActionResult Register(CustomerForRegisterDto customerForRegisterDto)
        {   
            var result =_customerAuthService.Register(customerForRegisterDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
