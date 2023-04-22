using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRestaurantController : ControllerBase
    {
        private readonly IFavoriteRestaurnatService _favoriteRestaurnatService;
        private readonly IMapper _mapper;

        public FavoriteRestaurantController(IFavoriteRestaurnatService favoriteRestaurnatService, IMapper mapper)
        {
            _favoriteRestaurnatService = favoriteRestaurnatService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(FavoriteRestaurantDto favoriteRestaurantDto)
        {
            var map = _mapper.Map<FavoriteRestaurant>(favoriteRestaurantDto);
            var result=_favoriteRestaurnatService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetALl()
        {
            var result = _favoriteRestaurnatService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _favoriteRestaurnatService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetFavoriteRestaurantByCustomerID")]
        public IActionResult GetFavoriteRestaurantByCustomerID(string id)
        {
            var result = _favoriteRestaurnatService.GetFavoriteRestaurantsByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
