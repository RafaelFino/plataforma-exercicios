using Microsoft.AspNetCore.Mvc;
using CRUD.Interfaces;
using CRUD.Domain;
using CRUD.Commons;
using CRUD.Services;

namespace CRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        Logger.GetInstance().Log("[ClientController] Initializing ClientController with provided service.");
        _clientService = clientService;
    }

    // GET: api/client?includeInactive=true
    [HttpGet]
    public IActionResult GetAll([FromQuery] bool includeInactive = false)
    {
        Logger.GetInstance().Log($"[ClientController] GetAll called. includeInactive={includeInactive}");

        var clients = _clientService.GetAll(includeInactive);

        return Ok(clients);
    }

    // GET: api/client/filtered?name=John
    [HttpGet("filtered")]
    public IActionResult GetFiltered()
    {
        Logger.GetInstance().Log("[ClientController] GetFiltered called.");

        var filters = Request.Query.ToDictionary(
            q => q.Key,
            q => q.Value.ToString()
        );

        var clients = _clientService.GetFiltered(filters);

        return Ok(clients);
    }

    // GET: api/client/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        Logger.GetInstance().Log($"[ClientController] GetById called. id={id}");

        var client = _clientService.GetByID(id);

        if (client == null)
        {
            Logger.GetInstance().Log($"[ClientController] Client not found. id={id}");
            return NotFound(new { id });
        }

        return Ok(client);
    }

    // POST: api/client
    [HttpPost]
    public IActionResult Create(
        [FromForm] string name,
        [FromForm] string email,
        [FromForm] DateTime birthDate)
    {
        Logger.GetInstance().Log($"[ClientController] Create called. name={name}, email={email}");

        var id = _clientService.Create(name, email, birthDate);

        if (string.IsNullOrEmpty(id))
        {
            Logger.GetInstance().Log("[ClientController] Failed to create client.");
            return BadRequest(new { name, email });
        }

        Logger.GetInstance().Log($"[ClientController] Client created successfully. id={id}");

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    // PUT: api/client/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UpdateClientRequest clientUpdated)
    {
        Logger.GetInstance().Log($"[ClientController] Update called. id={id}");

        var updated = _clientService.Update(id, clientUpdated);

        if (!updated)
        {
            Logger.GetInstance().Log($"[ClientController] Client not found for update. id={id}");
            return NotFound(new { id });
        }

        Logger.GetInstance().Log($"[ClientController] Client updated successfully. id={id}");

        return Ok(new { id });
    }

    // DELETE: api/client/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        Logger.GetInstance().Log($"[ClientController] Delete called. id={id}");

        var deleted = _clientService.Delete(id);

        if (!deleted)
        {
            Logger.GetInstance().Log($"[ClientController] Client not found for deletion. id={id}");
            return NotFound(new { id });
        }

        Logger.GetInstance().Log($"[ClientController] Client deleted successfully. id={id}");

        return Ok(new { id });
    }
}