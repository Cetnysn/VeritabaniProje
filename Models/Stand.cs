using System.Collections;
using System.Collections.Generic;

namespace VeritabanıProje.Models
{
	public class Stand
	{
		public int Id { get; set; }
		public int salon_no { get; set; }
		public int stand_no { get; set; }
		public Sirket sirket_ { get; set; }
		public string sirket_isim { get; set; }
		public Fuar fuar_ { get; set; }
		public string fuar_isim { get;set; }
	}
}
