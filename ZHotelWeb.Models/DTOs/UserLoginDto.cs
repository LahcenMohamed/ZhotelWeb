using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models.DTOs
{
	public class UserLoginDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
