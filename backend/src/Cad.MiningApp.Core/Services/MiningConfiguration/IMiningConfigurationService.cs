namespace Cad.MiningApp.Core.Services.MiningConfiguration;

public interface IMiningConfigurationService
{
    Task SetConfigurationAsync(Model.MiningConfiguration configuration);
}