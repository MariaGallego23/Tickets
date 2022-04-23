using ConcertTickets.Data.Entities;

namespace ConcertTickets.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task  SearchAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();
            await CheckEntranceAsync();
        }

        private async Task CheckEntranceAsync()
        {
            if (! _context.Entrances.Any())
            {
                _context.Add(new Entrance { Description = "Sur" });
                _context.Add(new Entrance { Description = "Norte" });
                _context.Add(new Entrance { Description = "Occidental" });
                _context.Add(new Entrance { Description = "Oriental" });
            }
            await _context.SaveChangesAsync();
        }


        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i < 5000; i++)
                {
                    _context.Add(new Ticket
                    {
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrance = null,
                    });
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
