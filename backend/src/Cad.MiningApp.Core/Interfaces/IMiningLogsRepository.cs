using Cad.MiningApp.Core.Enums;
using Cad.MiningApp.Core.Model;

namespace Cad.MiningApp.Core.Interfaces;

public interface IMiningLogsRepository
{
    Task AddAsync(MiningLog miningLog);

    Task<int> GetQuantityAsync(ResourceType resourceType);

    IList<MiningReportDto> GetMiningReport(DateTime? startTime = null, int granularityInMinutes = 1);
}