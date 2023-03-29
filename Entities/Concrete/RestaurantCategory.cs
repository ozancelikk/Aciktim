using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class RestaurantCategory:IEntity
	{
		public string Id { get; set; }
		public string? RestaurantCategoryName { get; set; }
	}
}
