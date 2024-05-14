using System.ComponentModel.DataAnnotations;
namespace zadaniePiekarniaMVC.Models
{
    public class Piekarnia
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        
        public string? Rodzaj { get; set; }
        public decimal Cena { get; set; }
    }
}
