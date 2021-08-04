using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public string Gorsel { get; set; }
        public int Turid { get; set; }
        public virtual Tur Tur { get; set; }
        public ICollection<Sepet> Sepets { get; set; }
        public ICollection<Siparisler> Siparislers { get; set; }

    }
}