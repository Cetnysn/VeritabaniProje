using System.Collections;
using System.Collections.Generic;

namespace VeritabanıProje.Models
{
	public class Sirket
	{
		public int Id { get; set; }
		public string isim { get; set; }
		public Sektor sektor_ { get; set; }
		public string sektor_adı { get; set; }
		public string yetkili { get; set; }
		public string yetkiliTel { get; set; }
		public string yetkiliMail { get; set; }
		public Fuar fuar_ { get; set; }
		public string fuar_isim { get; set; }
		public bool? onay { get; set; }
		public int salon_no { get; set; }
		public int stand_no { get; set; }

	}
}
