using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IsvicreGeziRehberi.Model
{
    public class Kullanici
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ad { get; set; }
        [StringLength(50)]
        public string Soyad { get; set; }
        [StringLength(50), EmailAddress]
        public string Email { get; set; }
        [StringLength(15)]
        public string Sifre { get; set; }
        public bool AktiflikDurumu { get; set; }
        public int RolID { get; set; }

        public KullaniciRolu? KullaniciRolu { get; set; }
        public DateTime? KayitTarihi { get; set; } = DateTime.Now;

    }
}
