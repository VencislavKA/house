using HouseRent4.Data;
using HouseRent4.Models;
using HouseRent4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRent4.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private ApplicationDbContext Context { get; }

		public HomeController(ILogger<HomeController> logger,
			ApplicationDbContext context)
		{
			_logger = logger;
			Context = context;
		}

		public IActionResult Index()
		{
			var main = Context.Gallery.Where(x => x.Title == "main").ToList();
			var mainG = Context.Gallery.Where(x => x.Title == "mainG").ToList();




			var about = Context.About.FirstOrDefault();
			if(about == null)
			{
				Context.About.Add(new About
				{
					Title = "За нас",
					Text = "Текст към полето за нас"
				});
				Context.SaveChanges();
			}
			var contact = Context.Contact.FirstOrDefault();
			if (contact == null)
			{
				Context.Contact.Add(new Contact
				{
					Adress = "Адрес",
					Email = "Имейл",
					Phone = "Телефон"
				});
				Context.SaveChanges();
			}
			var home = Context.Home.FirstOrDefault();
			if (home == null)
			{
				Context.Home.Add(new Home
				{
					text1 = "Текст 1",
					text2 = "Текст 2"
				});
				Context.SaveChanges();
			}
			var price = Context.Prices.FirstOrDefault();
			if (price == null)
			{
				Context.Prices.Add(new Prices
				{
					Price1 = 0,
					Price2 = 0,
					Price3 = 0,
					Price4 = 0,
					Price5 = 0,
					Price6 = 0,
					Price7 = 0
				});
				Context.SaveChanges();
			}
			var specials = Context.Specials.FirstOrDefault();
			if (specials == null)
			{
				Context.Specials.Add(new Specials { title = "Удобства" });
				Context.SaveChanges();
			}

			var index = new IndexViewModel { About = about,Contact = contact,Home = home,Prices = price, Specials = specials, main = main, mainG = mainG };
			return View(index);
		}

		public IActionResult Gallery()
		{
			var about = Context.About.FirstOrDefault();
			if (about == null)
			{
				Context.About.Add(new About
				{
					Title = "За нас",
					Text = "Текст към полето за нас"
				});
				Context.SaveChanges();
			}

			var specials = Context.Specials.FirstOrDefault();
			if (specials == null)
			{
				Context.Specials.Add(new Specials { title = "Удобства" });
				Context.SaveChanges();
			}
			var gallery = Context.Gallery.ToList();
			var GalleryViewModel = new GalleryViewModel() { AboutTitle = about.Title, SpecialsTitile = specials.title, Images = gallery, };

			return View(GalleryViewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
