using System.ComponentModel.DataAnnotations;

namespace IsvicreGeziRehberi.Model
{
    public class Gonderi
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string? Baslik { get; set; }

        public string? Icerik { get; set; }

        public string? Fotograf { get; set; }

        public bool AktiflikDurumu { get; set; }
        public string? OlusturanKullanici { get; set; }
        public int KategoriID { get; set; }

        public GonderiKategori? GonderiKategori { get; set; }
        public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}
