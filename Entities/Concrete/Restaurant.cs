using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Restaurant:IEntity
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Taxnumber { get; set; }
		public string? Address { get; set; }
		public int RestaurantCategoryId { get; set; }
		public string? OpeningTime { get; set; }
		public string? ClosingTime { get; set; }
	}
}
