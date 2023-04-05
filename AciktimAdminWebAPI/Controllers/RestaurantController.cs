using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _restaurantService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(string id)
        {
            var result = _restaurantService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetailsbyid")]

        public IActionResult GetDetailsById(string id)
        {
            var result = _restaurantService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbymail")]

        public IActionResult GetByMail(string mail)
        {
            var result = _restaurantService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getclaims")]

        public IActionResult GetClaims(Restaurant restaurant) 
        {
            var result = _restaurantService.GetClaims(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(Restaurant restaurant)
        {
            var result = _restaurantService.Add(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(Restaurant restaurant)
        {
            var result = _restaurantService.Update(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]

        public IActionResult Delete(string id)
        {
            var result = _restaurantService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("changeforgottenpassword")]

        public IActionResult ChangeForgottenPassword(Restaurant restaurant)
        {
            var result = _restaurantService.ChangeForgottenPassword(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
