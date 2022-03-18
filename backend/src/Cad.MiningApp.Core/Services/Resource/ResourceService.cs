using Cad.MiningApp.Core.Enums;
using Cad.MiningApp.Core.Interfaces;

namespace Cad.MiningApp.Core.Services.Resource;

public class ResourceService : IResourceService
{
    private readonly IMiningLogsRepository _repository;

    public ResourceService(IMiningLogsRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> GetMinedQuantityAsync()
    {
        return await _repository.GetQuantityAsync(ResourceType.Titanium);
    }

    public async Task<int> AddMinedQuantityAsync()
    {
        return await _repository.GetQuantityAsync(ResourceType.Titanium);
    }
}