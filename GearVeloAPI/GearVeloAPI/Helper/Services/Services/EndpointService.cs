using GearVeloAPI.Helper.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GearVeloAPI.Helper.Services.Services;

public class EndpointService : IEndpointService
{
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

    public EndpointService(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    }

    public IEnumerable<string> GetEndpointsWithHttpGet()
    {
        var actionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items;

        var httpGetEndpoints = actionDescriptors
            .OfType<ControllerActionDescriptor>()
            .Where(ad => ad.EndpointMetadata.OfType<HttpGetAttribute>().Any())
            .Select(ad => ad.AttributeRouteInfo!.Template)
            .ToList();

        return httpGetEndpoints!;
    }
}












