using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantSupportController : ControllerBase
    {
        private IRestaurantSupportService _restaurantSupportService;
        private IMapper _mapper;
        public RestaurantSupportController(IRestaurantSupportService restaurantSupportService, IMapper mapper)
        {
            _restaurantSupportService = restaurantSupportService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _restaurantSupportService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(RestaurantSupportDto restaurantSupportDto)
        {
            var map = _mapper.Map<RestaurantSupport>(restaurantSupportDto);
            var result = _restaurantSupportService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetMailDetails")]
        public IActionResult GetMailDetails()
        {
            var result = _restaurantSupportService.GetMailDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetMailDetailsByRestaurantId")]
        public IActionResult GetMailDetailsByRestaurantId(string id)
        {
            var result = _restaurantSupportService.GetMailDetailsByRestaurantId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("delete")]

        public IActionResult Delete(string id)
        {
            var result = _restaurantSupportService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
