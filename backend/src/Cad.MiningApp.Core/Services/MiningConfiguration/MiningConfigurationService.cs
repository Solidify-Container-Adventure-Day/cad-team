namespace Cad.MiningApp.Core.Services.MiningConfiguration;

public class MiningConfigurationService : IMiningConfigurationService
{
    public async Task SetConfigurationAsync(Model.MiningConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        await Task.CompletedTask;
    }
}