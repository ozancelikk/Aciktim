using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Dtos;
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
