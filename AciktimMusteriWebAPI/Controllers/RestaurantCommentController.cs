﻿using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCommentController : ControllerBase
    {
        private readonly IRestaurantCommentService _restaurantCommentService;
        private readonly IMapper _mapper;

        public RestaurantCommentController(IRestaurantCommentService restaurantCommentService, IMapper mapper)
        {
            _restaurantCommentService = restaurantCommentService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(RestaurantCommentDto restaurantCommentDto)
        {
            var map = _mapper.Map<RestaurantComment>(restaurantCommentDto);
            map.Status = false;
            var result = _restaurantCommentService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _restaurantCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _restaurantCommentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetCommentsByRestaurantId")]
        public IActionResult GetCommentsByRestaurantId(string restaurantId)
        {
            var result = _restaurantCommentService.GetCommentByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCommentsByCustomerId")]
        public IActionResult GetCommentsByCustomerId(string customerId,string restaurantId)
        {
            var result = _restaurantCommentService.GetCommentByCustomerId(customerId,restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
