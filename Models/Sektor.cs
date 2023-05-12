using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;

namespace VeritabanıProje.Models
{
	public class Sektor
	{
		public int Id { get; set; }
		public string isim { get; set; }
		public virtual ICollection<Fuar> fuar { get; set; }
		public virtual ICollection<Sirket> sirket { get; set; }
	}
}
