using System.ComponentModel.DataAnnotations;

namespace VeritabanıProje.Models
{
	public class Ziyaretci
	{
        public  int Id { get; set; }
		public string isim { get; set; }
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
		public string tel { get; set; }
		public string email { get; set; }
        public Fuar fuar { get; set; }
		public string fuar_adı{ get; set; }
	}
}
