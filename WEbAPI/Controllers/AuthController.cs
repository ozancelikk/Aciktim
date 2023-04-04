using Business.Abstract;
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

        [HttpPost("register")]
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
    }
}
