using LaMiaPizzeria.Models.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio!")]
        [StringLength(100, ErrorMessage = "Il campo titolo può essere lungo al massimo 100 caratteri")]
        [MoreThanThreeWords(ErrorMessage = "Il campo titolo deve contenere almeno 3 parole!")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio!")]
        public string Description { get; set; }

        
        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [StringLength(300, ErrorMessage = "Il campo URL immagine può contenere al massimo 300 caratteri")]
        public string Image { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Il campo del prezzo è obbligatorio")]
        [MaxLength(4, ErrorMessage = "Il campo del prezzo può contenere al massimo 4 caratteri")]
        public float Price { get; set; }

        public Pizza()
        {

        }

        public Pizza(string title, string description, string image, float price)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
