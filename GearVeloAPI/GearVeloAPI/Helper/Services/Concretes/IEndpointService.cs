namespace GearVeloAPI.Helper.Services.Concretes;

public interface IEndpointService
{
    IEnumerable<string> GetEndpointsWithHttpGet();
}
