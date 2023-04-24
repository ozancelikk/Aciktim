using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantController : Controller	
	{
		private readonly IRestaurantService _restaurantService;
		private readonly IMapper _mapper;

		public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
		{
			_restaurantService = restaurantService;
			_mapper = mapper;
		}
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _restaurantService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
        [HttpGet("GetAllWithImage")]
        public IActionResult GetAllWithImage()
        {
            var result = _restaurantService.GetAllWithImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetRestaurantsByCategoryId")]
        public IActionResult GetRestaurantsByCategoryId(string categoryId)
        {
            var result = _restaurantService.GetRestaurantsByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
		public IActionResult GetById(string id)
		{
			var result = _restaurantService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
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

        [HttpGet("getdetailsdtobyid")]
        public IActionResult GetRestaurantDetailsById(string id)
        {
            var result = _restaurantService.GetRestaurantDetailByRestaurantId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
