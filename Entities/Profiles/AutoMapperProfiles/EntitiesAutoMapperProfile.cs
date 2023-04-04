﻿using AutoMapper;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Profiles.AutoMapperProfiles
{
    public class EntitiesAutoMapperProfile:Profile
    {
        public EntitiesAutoMapperProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<CategoryDto,Category>();
            CreateMap<MenuDto,Menu>();
            CreateMap<OrderDto,Order>();
            CreateMap<OrderCommentDto,OrderComment>();
            CreateMap<RestaurantDto,Restaurant>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<Restaurant,RestaurantDetailsDto>();

        }
    }
}
