using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRent4.Models
{
	public class Specials
	{
		public int Id { get; set; }

		[DisplayName("Заглавие")]
		public string title { get; set; }

		[DisplayName("Заглавие 1")]
		public string title1 { get; set; }

		[DisplayName("Текст 1")]
		public string text1 { get; set; }

		[DisplayName("Цена 1")]
		public string price1 { get; set; }

		[DisplayName("Снимка 1")]
		public string pic1 { get; set; }

		[DisplayName("Заглавие 2")]
		public string title2 { get; set; }

		[DisplayName("Текст 2")]
		public string text2 { get; set; }

		[DisplayName("Цена 2")]
		public string price2 { get; set; }

		[DisplayName("Снимка 2")]
		public string pic2 { get; set; }

		[DisplayName("Заглавие 3")]
		public string title3 { get; set; }

		[DisplayName("Текст 3")]
		public string text3 { get; set; }

		[DisplayName("Цена 3")]
		public string price3 { get; set; }

		[DisplayName("Снимка 3")]
		public string pic3 { get; set; }

		[DisplayName("Заглавие 4")]
		public string title4 { get; set; }

		[DisplayName("Текст 4")]
		public string text4 { get; set; }

		[DisplayName("Цена 4")]
		public string price4 { get; set; }

		[DisplayName("Снимка 4")]
		public string pic4 { get; set; }

		public string title5 { get; set; }

		public string text5 { get; set; }

		public string price5 { get; set; }

		public string pic5 { get; set; }

		public string title6 { get; set; }

		public string text6 { get; set; }

		public string price6 { get; set; }

		public string pic6 { get; set; }
	}
}
