using AutoMapper;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Concrete.Simples;
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
            CreateMap<Customer, CustomerDto>();
            CreateMap<CategoryDto,Category>();
            CreateMap<MenuDto,Menu>();
            CreateMap<OrderDto,Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderCommentDto,OrderComment>();
            CreateMap<OrderComment, OrderCommentDto>();
            CreateMap<RestaurantDto,Restaurant>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<CustomerDetailsDto, Customer>();
            CreateMap<Restaurant,RestaurantDetailsDto>();
            CreateMap<CustomerAddresses,CustomerAddressesDto>();
            CreateMap<CustomerAddressesDto, CustomerAddresses>();
            CreateMap<CustomerOperationClaim,CustomerOperationClaimDto>();
            CreateMap<CustomerOperationClaimDto, CustomerOperationClaim>();
            CreateMap<CustomerClaimsDetailsDto, Customer>();
            CreateMap<Customer, CustomerClaimsDetailsDto>();
            CreateMap<Order, OrderDetailsDto>();
            CreateMap<OrderDetailsDto, Order>();
            CreateMap<RestaurantClaimDetailsDto, RestaurantOperationClaim>();
            CreateMap<RestaurantOperationClaim, RestaurantClaimDetailsDto>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<UserDetailsDto, User>();
            CreateMap<FavoriteRestaurantDto ,FavoriteRestaurant>();
            CreateMap<FavoriteRestaurant, FavoriteRestaurantDto>();
            CreateMap<FavoriteRestaurantDetailsDto, FavoriteRestaurant>();
            CreateMap<FavoriteRestaurant, FavoriteRestaurantDetailsDto>();
            CreateMap<RestaurantImage, RestaurantImageDto>();
            CreateMap<RestaurantImageDto, RestaurantImage>();
            CreateMap<AddCategoryImageDto,CategoryImage>();
            CreateMap<CategoryImage, CategoryImageDto>();
            CreateMap<MenuImage, MenuImageDto>();
            CreateMap<MenuImageDto, MenuImage>();
            CreateMap<FavoriteRestaurantDto, FavoriteRestaurant>();
            CreateMap<FavoriteRestaurant, FavoriteRestaurantDto>();
            CreateMap<RestaurantImageDetailDto, Restaurant>();
            CreateMap<Restaurant, RestaurantImageDetailDto>();
            CreateMap<RestaurantCommentDto, RestaurantComment>();
            CreateMap<RestaurantComment, RestaurantCommentDto>();
            CreateMap<Support,SupportDto>();
            CreateMap<SupportDto, Support>();
            CreateMap<RestaurantForUpdateDto, Restaurant>();
            CreateMap<Restaurant, RestaurantForUpdateDto>();
            CreateMap<RestaurantImage, UpdateRestaurantImageDto>();
            CreateMap<UpdateRestaurantImageDto, RestaurantImage>();
        }
    }
}
