using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }
        public decimal ToplamTutar { get; set; }
        public virtual Siparisler Siparisler { get; set; }
        public int Siparisid { get; set; }
        public DateTime Tarih { get; set; }
    }
}