using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
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
            if(result.Success) 
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
        
    }
}
