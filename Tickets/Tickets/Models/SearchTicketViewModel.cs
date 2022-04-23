using System.ComponentModel.DataAnnotations;

namespace ConcertTickets.Models
{
    public class SearchTicketViewModel
    {       
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Id { get; set; }

    }
}
