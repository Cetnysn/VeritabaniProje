using System.ComponentModel.DataAnnotations;

namespace VeritabanıProje.Models
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }
		
		public string username { get; set; }
		public string password { get; set; }

	}
}
