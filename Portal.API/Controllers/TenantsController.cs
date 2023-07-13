using Application.Multitenancy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TenantsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TenantsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public Task<string> CreateAsync(CreateTenantRequest request)
    {
        return _mediator.Send(request);
    }
}
