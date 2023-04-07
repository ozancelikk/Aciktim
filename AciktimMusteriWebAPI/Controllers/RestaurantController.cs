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
		[HttpPost("Add")]
		public IActionResult Add(RestaurantDto restaurantDto)
		{
			var restaurant = _mapper.Map<Restaurant>(restaurantDto);
			var result = _restaurantService.Add(restaurant);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("Update")]
		public IActionResult Update(Restaurant restaurant)
		{
			var result = _restaurantService.Update(restaurant);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("Delete")]
		public IActionResult Delete(string id)
		{
			var result = _restaurantService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
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
		[HttpPost("changeforgottenpassword")]

		public IActionResult ChangeForgottenPassword(ForgottenPassword forgottenPassword)
		{
			var result = _restaurantService.ChangeForgottenPassword(forgottenPassword);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Message);
		}
	}
}
