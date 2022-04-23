using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcertTickets.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();
    }
}