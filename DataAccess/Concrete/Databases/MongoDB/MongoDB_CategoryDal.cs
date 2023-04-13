using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_CategoryDal:MongoDB_RepositoryBase<Category, MongoDB_Context<Category, MongoDB_CategoryCollection>>,ICategoryDal
    {
        public List<CategoryImageDto> GetAllCategoriesWithImages()
        {
            List<Category> category = new List<Category>();
            using (var categories = new MongoDB_Context<Category, MongoDB_CategoryCollection>())
            {
                categories.GetMongoDBCollection();
                category = categories.collection.Find<Category>(document => true).ToList();
            }
            var list = new List<CategoryImageDto>();
            List<CategoryImage> categoryImage = new List<CategoryImage>();
            using (var categoryImages = new MongoDB_Context<CategoryImage, MongoDB_CategoryImageCollection>())
            {
                categoryImages.GetMongoDBCollection();
                categoryImage = categoryImages.collection.Find<CategoryImage>(document => true).ToList();
            }

            foreach (var item in category)
            {
                var temp = categoryImage.Find(x => x.CategoryId == item.Id);
                if(temp !=null)
                {
                    list.Add(new CategoryImageDto
                    {
                        CategoryName = item.CategoryName,
                        Id = item.Id,
                        ImagePath = temp.ImagePath
                    });
                }
                
            }
            return list;
        }
    }
}
