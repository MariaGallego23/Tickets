using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tickets.Data;

namespace Tickets.Helpers
{
    public class CombosHelper : ICombosHelper

    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboEntranceAsync()
        {
            List<SelectListItem> List = await _context.Entrances.Select(e => new SelectListItem
            {
                Text = e.Description,
                Value = e.Id.ToString()
            })
                     .OrderBy(e => e.Text)
                     .ToListAsync();

            List.Insert(0, new SelectListItem { Text = "[Seleccione una entrada...]", Value = "0" });

            return List;
        }
    }
}
