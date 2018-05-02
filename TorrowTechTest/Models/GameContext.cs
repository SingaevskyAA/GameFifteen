using Microsoft.EntityFrameworkCore;

namespace TorrowTechTest.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)  
            : base(options)
        {            
        }

        public DbSet<GameState> GameStates { get; set; }
    }
}
