using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Tur
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        public ICollection<Menu> Menus { get; set; }

    }
}