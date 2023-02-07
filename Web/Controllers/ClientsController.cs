using Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientRepository _repository;

        public ClientsController(IMediator mediator, IClientRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet("{clientCode}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientCode)
        {
            var client = await _repository.GetClient(clientCode);

            return Ok(client);
        }
    }
}
