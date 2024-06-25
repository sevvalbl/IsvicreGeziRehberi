using System.ComponentModel.DataAnnotations;

namespace IsvicreGeziRehberi.Model
{
    public class Iletisim
    {
        public int Id { get; set; }
    
        public string Ad { get; set; }
       
        public string Soyad { get; set; }
        [StringLength(50), EmailAddress]
        public string? Email { get; set; }
        
        public string Ileti { get; set; }
      
        public string? Telefon { get; set; }

    
        public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}
