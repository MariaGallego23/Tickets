using System.ComponentModel.DataAnnotations;

namespace Tickets.Data.Entities
{
    public class Ticket
    {      
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Id { get; set; }

        public bool WasUsed { get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }


        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Fecha de la Compra")]
        public DateTime? Date { get; set; }

        public Entrance? Entrance { get; set; }
    }
}
