using Core.DataAccess.Databases.MongoDB;
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


            foreach (var item in menus)
            {
                if (item.RestaurantId == restaurantId)
                {
                    var menuImage = menuImages.Find(x => x.MenuId == item.Id); //menüımage

                    if (menuImage!= null)
                    {
                        list.Add(new MenuDetailsDto
                        {
                            MenuDescription = item.MenuDescription,
                            MenuImage = menuImage.ImagePath,
                            MenuPrice = item.MenuPrice,
                            MenuTitle = item.MenuTitle
                        });
                    }
                }

            }
            return list;
        }
    }
}
