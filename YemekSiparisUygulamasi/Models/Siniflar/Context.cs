using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Tur> Turs { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Siparisler> Siparislers { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
    }
}