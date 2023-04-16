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
    public class MenuImageController : ControllerBase
    {
        private IMenuImageService _menuImageService;
        private IMapper _mapper;

        public MenuImageController(IMenuImageService menuImageService, IMapper mapper)
        {
            _menuImageService = menuImageService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] MenuImageDto menuImageDto)
        {
            var map = _mapper.Map<MenuImage>(menuImageDto);
            var result = _menuImageService.Add(file, map);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _menuImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetImagesByRestaurantId")]
        public IActionResult GetImagesByRestaurantId(string menuId)
        {
            var result = _menuImageService.GetByImageId(menuId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
