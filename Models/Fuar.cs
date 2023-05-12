using System;
using System.Collections;
using System.Collections.Generic;

namespace VeritabanıProje.Models
{
	public class Fuar
	{
        public int Id { get; set; }
		public string isim { get; set; }
		public DateTime tarih { get; set; }
		public string sektor_adı { get; set; }
		public Sektor sektor { get; set; }
		public bool aktif { get; set; }
		public virtual ICollection<Ziyaretci> ziyaretci { get; set; }
		public virtual ICollection<Stand> standlar{ get; set; }

    }
}
