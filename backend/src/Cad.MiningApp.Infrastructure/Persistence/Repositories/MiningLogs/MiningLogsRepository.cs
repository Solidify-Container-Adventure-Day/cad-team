using Cad.MiningApp.Core.Enums;
using Cad.MiningApp.Core.Interfaces;
using Cad.MiningApp.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Cad.MiningApp.Infrastructure.Persistence.Repositories.MiningLogs;

public class MiningLogsRepository : IMiningLogsRepository
{
    private readonly MiningAppDbContext _dbContext;

    public MiningLogsRepository(MiningAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(MiningLog miningLog)
    {
        if (miningLog == null)
        {
            throw new ArgumentNullException(nameof(miningLog));
        }

        await _dbContext.AddAsync(miningLog);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetQuantityAsync(ResourceType resourceType)
    {
        return await _dbContext.MiningLogs
            .Where(m => m.ResourceType == resourceType)
            .SumAsync(m => m.Quantity);
    }

    public IList<MiningReportDto> GetMiningReport(DateTime? startTime, int granularityInMinutes = 1)
    {
        return _dbContext.MiningLogs
            .Where(l => startTime == null || l.CompletedOn >= startTime)
            .Select(l => new { Quantity = l.Quantity, Time = GetNormalized(l.CompletedOn, granularityInMinutes) })
            .AsEnumerable()
            .GroupBy(l => l.Time)
            .Select(g => new MiningReportDto { Time = g.Key, Quantity = g.Sum(x => x.Quantity) })
            .ToList();
    }

    public static DateTimeOffset GetNormalized(DateTimeOffset dateTime, int minutesCount)
    {
        var unixTime = dateTime.ToUnixTimeSeconds();
        DateTimeOffset dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();
        DateTimeOffset result = dtDateTime.AddMinutes(-(dtDateTime.Minute % minutesCount));
        result = result.AddMilliseconds(-result.Millisecond - 1000 * result.Second);

        return result;
    }
}