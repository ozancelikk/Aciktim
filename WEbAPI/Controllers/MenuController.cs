using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService  _menuService;
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
            var result= _menuService.Add(menu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddMenuWithImage")]
        public IActionResult AddWithMenuImage(MenuDto menuDto)
        {
            var menu = _mapper.Map<Menu>(menuDto);
            var result = _menuService.AddMenuWithImage(menu);
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
        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _menuService.Delete(id);
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
