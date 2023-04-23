using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_MenuDal : MongoDB_RepositoryBase<Menu, MongoDB_Context<Menu, MongoDB_MenuCollection>>, IMenuDal
    {
        public List<MenuDetailsDto> GetMenusByRestaurantId(string restaurantId)
        {

            var list = new List<MenuDetailsDto>();

            List<MenuImage> menuImages = new List<MenuImage>();
            using var menutImageContext = new MongoDB_Context<MenuImage, MongoDB_MenuImageCollection>();
            menutImageContext.GetMongoDBCollection();
            menuImages = menutImageContext.collection.Find<MenuImage>(document => true).ToList();

            List<Menu> menus = new List<Menu>();
            using var menuContext = new MongoDB_Context<Menu, MongoDB_MenuCollection>();
            menuContext.GetMongoDBCollection();
            menus = menuContext.collection.Find<Menu>(document => true).ToList();

            List<Restaurant> restaurants = new List<Restaurant>();
            using var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>();
            restaurantContext.GetMongoDBCollection();
            restaurants = restaurantContext.collection.Find<Restaurant>(document => true).ToList();


            foreach (var item in menus)
            {
                //if (item.RestaurantId == restaurantId)
                //{
                //    var menuImage = menuImages.Find(x => x.MenuId == item.Id); //menüımage
                //    var restaurant = restaurants.Find(x => x.Id == item.RestaurantId); //menüımage

                //    if (menuImage != null)
                //    {
                //        list.Add(new MenuDetailsDto
                //        {
                //            MenuDescription = item.MenuDescription,
                //            MenuImage = menuImage.ImagePath,
                //            MenuPrice = item.MenuPrice,
                //            MenuTitle = item.MenuTitle,
                //            Id = item.Id,
                //            RestaurantName = restaurant.RestaurantName,
                //            RestaurantId = restaurant.Id,
                //        });
                //    }
                //}



                if (item.RestaurantId == restaurantId)
                {
                    var restaurant = restaurants.Find(x => x.Id == item.RestaurantId); //restaurant
                    var temp = new MenuDetailsDto()
                    {
                        MenuDescription = item.MenuDescription,
                        //MenuImage = menuImage.ImagePath,
                        MenuPrice = item.MenuPrice,
                        MenuTitle = item.MenuTitle,
                        Id = item.Id,
                        RestaurantName = restaurant.RestaurantName,
                        RestaurantId = restaurant.Id,
                    };
                    var menuImage = menuImages.Find(x => x.MenuId == item.Id); //menüımage
                    temp.MenuImage = menuImage != null ? menuImage.ImagePath : null;
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
