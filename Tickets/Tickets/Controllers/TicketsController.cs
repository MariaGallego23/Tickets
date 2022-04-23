using ConcertTickets.Data;
using ConcertTickets.Data.Entities;
using ConcertTickets.Helpers;
using ConcertTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcertTickets.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public TicketsController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return NotFound();
                }
                Ticket ticket = await _context.Tickets.FindAsync(model.Id);
                if (ticket == null)
                {
                    ModelState.AddModelError(string.Empty, "La boleta no existe");
                    return View(model);
                }
                if (ticket.WasUsed == false)
                {
                    return RedirectToAction(nameof(Form), new { id = ticket.Id });
                }
                else
                {
                    return RedirectToAction(nameof(Details), new { id = ticket.Id });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Form(int id)
        {
            TicketViewModel model = new()
            {
                Id = id,
                Entrances = await _combosHelper.GetComboEntrancesAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Form(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return NotFound();
                }

                Ticket ticket = await _context.Tickets.FindAsync(model.Id);
                ticket.WasUsed = true;
                ticket.Document = model.Document;
                ticket.Name = model.Name;
                ticket.Date = DateTime.Today;
                ticket.Entrance = await _context.Entrances.FindAsync(model.EntranceId);
                _context.Update(ticket);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = ticket.Id });
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            Ticket ticket = await _context.Tickets
                .Include(t => t.Entrance)
                .FirstOrDefaultAsync(t => t.Id == Id);
            return View(ticket);
        }

    }
}
