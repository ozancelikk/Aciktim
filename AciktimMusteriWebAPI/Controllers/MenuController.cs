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
		[HttpPost("Add")]
		public IActionResult Add(MenuDto menuDto)
		{
			var menu = _mapper.Map<Menu>(menuDto);
			var result = _menuService.Add(menu);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("Update")]
		public IActionResult Update(Menu menu)
		{
			var result = _menuService.Update(menu);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("Delete")]
		public IActionResult Delete(string id)
		{
			var result = _menuService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
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
	}
}
