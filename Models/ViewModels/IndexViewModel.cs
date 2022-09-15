using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRent4.Models.ViewModels
{
	public class IndexViewModel
	{
		public About About { get; set; }

		public Contact Contact { get; set; }

		public Home Home { get; set; }

		public Prices Prices { get; set; }

		public Specials Specials { get; set; }

		public List<Gallery> main { get; set; }

		public List<Gallery> mainG { get; set; }
	}
}
