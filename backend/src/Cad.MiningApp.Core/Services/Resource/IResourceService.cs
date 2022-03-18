namespace Cad.MiningApp.Core.Services.Resource;

public interface IResourceService
{
    Task<int> GetMinedQuantityAsync();
}