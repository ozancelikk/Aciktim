﻿using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
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
            return BadRequest(result.Message);

        }
        [HttpPost("AddMenuWithImage")]
        public IActionResult AddWithMenuImage(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            var result = _restaurantService.AddRestaurantWithImage(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetALl()
        {
            var result = _restaurantService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("GetDetailsById")]
        public IActionResult GetDetailsById(string id)
        {
            var result = _restaurantService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("ChangeRestaurantActiveStatus")]
        public IActionResult ChangeRestaurantActiveStatus(RestaurantDto restaurant)
        {
            var x = _restaurantService.GetById(restaurant.Id);
            var map = _mapper.Map<Restaurant>(restaurant);
            map.RestaurantStatus = false;
            map.Status = x.Data.Status;
            map.PasswordSalt = x.Data.PasswordSalt;
            map.PasswordHash = x.Data.PasswordHash;
            map.RestaurantStatus = true;
            var result = _restaurantService.Update(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("ChangeRestaurantPassiveStatus")]
        public IActionResult ChangeRestaurPassiveStatus(RestaurantDto restaurant)
        {
            var x = _restaurantService.GetById(restaurant.Id);
            var map = _mapper.Map<Restaurant>(restaurant);
            map.RestaurantStatus = false;
            map.Status = x.Data.Status;
            map.PasswordSalt = x.Data.PasswordSalt;
            map.PasswordHash = x.Data.PasswordHash;
            var result = _restaurantService.Update(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Restaurant restaurant)
        {
            var result = _restaurantService.Update(restaurant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _restaurantService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _restaurantService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("ChangeForgottenPassword")]
        public IActionResult ChangeForgottenPassword(Restaurant restaurant)
        {
            var result = _restaurantService.ChangeForgottenPassword(restaurant);
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
