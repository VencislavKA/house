using HouseRent4.Data;
using HouseRent4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using HouseRent4.Models.ViewModels;

namespace HouseRent4.Controllers
{
	public class AdminController : Controller
	{
		public AdminController(ApplicationDbContext context, IHostingEnvironment environment)
		{
			Environment = environment;
			Context = context;
		}

		[Obsolete]
		public IHostingEnvironment Environment { get; }

		private ApplicationDbContext Context { get; }

		public IActionResult AdminIndex()
		{
			
			var about = Context.About.FirstOrDefault();
			var contact = Context.Contact.FirstOrDefault();
			var home = Context.Home.FirstOrDefault();
			var price = Context.Prices.FirstOrDefault();
			var specials = Context.Specials.FirstOrDefault();

			var main = Context.Gallery.Where(x => x.Title == "main").ToList();
			var mainG = Context.Gallery.Where(x => x.Title == "mainG").ToList();

			var homeData = new IndexViewModel { About = about, Contact = contact, Home = home, Prices = price, Specials = specials, main = main, mainG = mainG };
			return View(homeData);
		}

		[HttpPost]
		public IActionResult AdminIndex(string text1, string text2)
		{
			var homeData = Context.Home.FirstOrDefault();
			homeData.text1 = text1;
			homeData.text2 = text2;
			Context.SaveChanges(); 
			var about = Context.About.FirstOrDefault();
			var contact = Context.Contact.FirstOrDefault();
			var price = Context.Prices.FirstOrDefault();
			var specials = Context.Specials.FirstOrDefault();

			var main = Context.Gallery.Where(x => x.Title == "main").ToList();
			var mainG = Context.Gallery.Where(x => x.Title == "mainG").ToList();

			var output = new IndexViewModel { About = about, Contact = contact, Home = homeData, Prices = price, Specials = specials, main = main, mainG = mainG };
			return View(output);
		}

		public IActionResult Specials()
		{
			var about = Context.About.FirstOrDefault();
			var contact = Context.Contact.FirstOrDefault();
			var home = Context.Home.FirstOrDefault();
			var price = Context.Prices.FirstOrDefault();
			var specials = Context.Specials.FirstOrDefault();

			var main = Context.Gallery.Where(x => x.Title == "main").ToList();
			var mainG = Context.Gallery.Where(x => x.Title == "mainG").ToList();

			var homeData = new IndexViewModel { About = about, Contact = contact, Home = home, Prices = price, Specials = specials, main = main, mainG = mainG };
			return View(homeData);
		}

		[HttpPost]
		public IActionResult Specials(Specials specials)
		{
			var specialData = Context.Specials.FirstOrDefault();
			Context.Remove(specialData);
			Context.Add(specials);
			Context.SaveChanges();
			var about = Context.About.FirstOrDefault();
			var contact = Context.Contact.FirstOrDefault();
			var home = Context.Home.FirstOrDefault();
			var price = Context.Prices.FirstOrDefault();

			var main = Context.Gallery.Where(x => x.Title == "main").ToList();
			var mainG = Context.Gallery.Where(x => x.Title == "mainG").ToList();

			var homeData = new IndexViewModel { About = about, Contact = contact, Home = home, Prices = price, Specials = specials, main = main, mainG = mainG };




			return View(homeData);
		}

		public IActionResult About()
		{
			if (Context.About.FirstOrDefault() == null)
			{
				Context.About.Add(new About
				{
					Title = "За нас",
					Text = "Текст към полето за нас"
				});
				Context.SaveChanges();
			}
			var aboutData = Context.About.FirstOrDefault();
			return View(aboutData);
		}

		[HttpPost]
		public IActionResult About(About about)
		{
			var aboutData = Context.About.FirstOrDefault();
			Context.Remove(aboutData);
			Context.Add(about);
			Context.SaveChanges();
			return View(about);
		}

		public IActionResult Price()
		{
			if (Context.Prices.FirstOrDefault() == null)
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
			var priceData = Context.Prices.FirstOrDefault();
			return View(priceData);
		}

		[HttpPost]
		public IActionResult Price(Prices prices)
		{
			var priceData = Context.Prices.FirstOrDefault();
			Context.Remove(priceData);
			Context.Add(prices);
			Context.SaveChanges();
			return View(prices);
		}

		public IActionResult Contact()
		{
			if (Context.Contact.FirstOrDefault() == null)
			{
				Context.Contact.Add(new Contact
				{
					Adress = "Адрес",
					Email = "Имейл",
					Phone = "Телефон"
				});
				Context.SaveChanges();
			}
			var contactData = Context.Contact.FirstOrDefault();
			return View(contactData);
		}

		[HttpPost]
		public IActionResult Contact(Contact contact)
		{
			var contactData = Context.Contact.FirstOrDefault();
			Context.Remove(contactData);
			Context.Add(contact);
			Context.SaveChanges();
			return View(contact);
		}

		public IActionResult Gallery()
		{

			var contactData = Context.Gallery.ToList();

			return View(contactData);
		}

		public int imageHeight { get; set; }

		public int imageWidth { get; set; }

		[HttpPost]
		[Obsolete]
		public IActionResult Gallery(string Title, IFormFile image)
		{
			var imageUpload = UploadFile(image).Result;
			if (imageUpload == "false")
			{
				return View("The File can not be upladed");
			}
			var model = new Gallery()
			{
				Image = imageUpload,
				Title = Title,
				imageWidth = imageWidth,
				imageHeight = imageHeight
			};
			Context.Gallery.Add(model);
			Context.SaveChanges();
			return View(Context.Gallery.ToList());
		}

		[HttpPost]
		public IActionResult DeletePhoto(string image) 
		{

			if (Context.Gallery.Where(x => x.Image == image).Count() == 0)
			{
				return RedirectToAction("Gallery");
			}
			var photo = Context.Gallery.Where(x => x.Image == image).FirstOrDefault();
			Context.Gallery.Remove(photo);
			Context.SaveChanges();
			var filename = image.Split("\\").Last();
			var imagePath = @"\Gallery\Images\";
			var uploadPath = this.Environment.WebRootPath + imagePath;
			if(System.IO.File.Exists(uploadPath + filename))
				System.IO.File.Delete(uploadPath + filename);

			return RedirectToAction("Gallery");

		}


		[Obsolete]
		[Authorize]
		private async Task<string> UploadFile(IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				var imagePath = @"\Gallery\Images\";
				var uploadPath = this.Environment.WebRootPath + imagePath;

				if (!Directory.Exists(uploadPath))
				{
					Directory.CreateDirectory(uploadPath);
				}

				var uniqFileName = Guid.NewGuid().ToString();
				var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
				string fullPath = uploadPath + filename;

				imagePath = imagePath + @"\";
				var filePath = @".." + Path.Combine(imagePath, filename);

				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}

				Image img = Image.FromFile(uploadPath + filename);
				imageHeight = img.Height;
				imageWidth = img.Width;
				img.Dispose();

				return filePath;
			}
			else
			{
				return null;
			}
		}
	}
}
