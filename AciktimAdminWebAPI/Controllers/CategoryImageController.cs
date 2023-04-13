using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryImageController : ControllerBase
    {
        private readonly ICategoryImageService _categoryImageService;
        private readonly IMapper _mapper;

        public CategoryImageController(ICategoryImageService categoryImageService, IMapper mapper)
        {
            _categoryImageService = categoryImageService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] AddCategoryImageDto addCategoryImageDto)
        {
            var map = _mapper.Map<CategoryImage>(addCategoryImageDto);
            var result = _categoryImageService.Add(file, map);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetImagesByCategoryId")]
        public IActionResult GetImagesByCategorytId(string restaurantId)
        {
            var result = _categoryImageService.GetByImagesByCategoryId(restaurantId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
