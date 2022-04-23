using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Models
{
    public class TicketViewModel
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre Completo")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Entrada")]
        [Range(1, 4, ErrorMessage = "Debes seleccionar una entrada")]
        public int EntranceId { get; set; }

        public IEnumerable<SelectListItem> Entrances { get; set; }


    }
}
