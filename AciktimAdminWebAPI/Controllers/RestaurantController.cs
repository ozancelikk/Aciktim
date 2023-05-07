using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
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

        [HttpGet("GetActiveRestaurantsWithImage")]
        public IActionResult GetAllWithImage()
        {
            var result = _restaurantService.GetActiveRestaurantsWithImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetPassiveRestaurantsWithImage")]

        public IActionResult GetPassiveRestaurantsWithImage()
        {
            var result = _restaurantService.GetPassiveRestaurantsWithImages();
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

        [HttpGet("GetRestaurantsOrderNumber")]
        public IActionResult GetRestaurantsOrderNumber()
        {
            var result = _restaurantService.GetRestaurantsOrderNumber();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetRestaurantDetailByRestaurantId")]
        public IActionResult GetRestaurantDetailByRestaurantId(string restaurantId)
        {
            var result = _restaurantService.GetRestaurantDetailByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(RestaurantDto restaurant)
        {
            var map = _mapper.Map<Restaurant>(restaurant);
            var result = _restaurantService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(RestaurantForUpdateDto restaurant)
        {
            restaurant.Status = true;
            var map = _mapper.Map<Restaurant>(restaurant);
            var result = _restaurantService.Update(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("delete")]

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
