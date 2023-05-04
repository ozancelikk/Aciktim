using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRestaurantAuthService _restaurantAuthService;

        public AuthController(IRestaurantAuthService restaurantAuthService)
        {
            _restaurantAuthService = restaurantAuthService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RestaurantForRegisterDto restaurantForRegisterDto)
        {
            var exists = _restaurantAuthService.UserExists(restaurantForRegisterDto.Email);

            if (!exists.Success)
            {
                return BadRequest(exists.Message);
            }

            var register = _restaurantAuthService.Register(restaurantForRegisterDto);
            var check = _restaurantAuthService.CreateAccessToken(register.Data);

            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            return Ok(check);
        }

        [HttpPost("login")]
        public ActionResult Login(RestaurantForLoginDto restaurantForLoginDto)
        {
            var userToLogin = _restaurantAuthService.Login(restaurantForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _restaurantAuthService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(CustomerChangePasswordDto customerChangePasswordDto)
        {
            var result = _restaurantAuthService.ChangePassword(customerChangePasswordDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
