using System.ComponentModel.DataAnnotations;

namespace IsvicreGeziRehberi.Model
{
    public class GonderiKategori
    {

        public int Id { get; set; }
        public string? KategoriAdi { get; set; }
        public ICollection<Gonderi> Gonderi { get; set; }
    }
}
