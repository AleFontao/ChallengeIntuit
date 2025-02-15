using ChallengeIntuit.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIntuit.DAL
{
    public class ChallengeIntuitContext : DbContext
    {
        public ChallengeIntuitContext(DbContextOptions<ChallengeIntuitContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
