using System.ComponentModel.DataAnnotations;

namespace ConcertTickets.Data.Entities
{
    public class Entrance
    {
        public int Id { get; set; }

        [Display(Name = "Entrada")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}


