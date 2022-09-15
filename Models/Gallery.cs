using static System.Net.Mime.MediaTypeNames;

namespace HouseRent4.Models
{
	public class Gallery
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Image { get; set; }

		public int imageHeight { get; set; }

		public int imageWidth { get; set; }
	}
}
