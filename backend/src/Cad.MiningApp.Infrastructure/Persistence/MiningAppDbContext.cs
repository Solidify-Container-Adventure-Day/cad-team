using Cad.MiningApp.Core.Model;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Cad.MiningApp.Infrastructure.Persistence;

public class MiningAppDbContext : DbContext
{
    public DbSet<MiningLog> MiningLogs { get; set; }

    public MiningAppDbContext(DbContextOptions<MiningAppDbContext> options)
        : base(options)
    {
    }
}