using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : Controller
	{
		private readonly IMenuService _menuService;
		private readonly IMapper _mapper;

		public MenuController(IMenuService menuService, IMapper mapper)
		{
			_menuService = menuService;
			_mapper = mapper;
		}
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _menuService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("GetById")]
		public IActionResult GetById(string id)
		{
			var result = _menuService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

        [HttpGet("GetMenuDetailsByRestaurantId")]
        public IActionResult GetMenuDetailsByRestaurantId(string restaurantId)
        {
            var result = _menuService.GetMenusDetailsByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
