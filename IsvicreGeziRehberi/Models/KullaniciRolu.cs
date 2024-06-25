

namespace IsvicreGeziRehberi.Model
{
    public class KullaniciRolu
    {
        public int Id { get; set; }
        public string RolAdi { get; set; }
        public ICollection<Kullanici>? Kullanici { get; set; }
    }
}
