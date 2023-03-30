using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class User:IEntity
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public string Email { get; set; }
		public string Tc { get; set; }
		public string? Address { get; set; }
		public string PhoneNumber { get; set; }	
	}
}
