using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantAuthController : ControllerBase
    {
        private readonly IRestaurantAuthService _restaurantAuthService;

        public RestaurantAuthController(IRestaurantAuthService restaurantAuthService)
        {
            _restaurantAuthService = restaurantAuthService;
        }

        [HttpGet("userexists")]
        public IActionResult UserExists(string email)
        {
            var result = _restaurantAuthService.UserExists(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
