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
            var result = _restaurantAuthService.Register(restaurantForRegisterDto);
            restaurantForRegisterDto.Status = true;

            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public ActionResult Login(RestaurantForLoginDto restaurantForLoginDto)
        {
            var restaurantToLogin = _restaurantAuthService.Login(restaurantForLoginDto);

            if (!restaurantToLogin.Success)
            {
                return BadRequest(restaurantToLogin.Message);
            }

            var result = _restaurantAuthService.CreateAccessToken(restaurantToLogin.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
