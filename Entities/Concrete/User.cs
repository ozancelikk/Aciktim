using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class User:IEntity
	{
		public string? Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int Age { get; set; }
		public string? Email { get; set; }
		public string? Tc { get; set; }
		public string? Address { get; set; }
		public int PhoneNumber { get; set; }	
	}
}
