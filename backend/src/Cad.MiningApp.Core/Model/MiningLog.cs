using Cad.MiningApp.Core.Enums;

namespace Cad.MiningApp.Core.Model;

public class MiningLog
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public ResourceType ResourceType { get; set; }
    
    public DateTimeOffset CompletedOn { get; set; }
}