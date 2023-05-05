using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantImageController : ControllerBase
    {
        private readonly IRestaurantImageService _restaurantImageService;
        private readonly IMapper _mapper;

        public RestaurantImageController(IRestaurantImageService restaurantImageService, IMapper mapper)
        {
            _restaurantImageService = restaurantImageService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] RestaurantImageDto restaurantImageDto)
        {
            var map = _mapper.Map<RestaurantImage>(restaurantImageDto);
            var result = _restaurantImageService.Add(file, map);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _restaurantImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetImagesByRestaurantId")]
        public IActionResult GetImagesByRestaurantId(string restaurantId)
        {
            var result = _restaurantImageService.GetByImagesByRestaurantId(restaurantId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] UpdateRestaurantImageDto restaurantImageDto)
        {
            var map = _mapper.Map<RestaurantImage>(restaurantImageDto);
            var result = _restaurantImageService.Update(file, map);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

    }
}
