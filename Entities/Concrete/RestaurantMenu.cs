using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class RestaurantMenu:IEntity
	{
		public string Id { get; set; }
		public string? RestaurantId { get; set; }
		public string? FoodCategoryId { get; set; }
		public string? MenuName { get; set; }
		public string? MenuDescription { get; set; }
		public double Price { get; set; }
	}
}
