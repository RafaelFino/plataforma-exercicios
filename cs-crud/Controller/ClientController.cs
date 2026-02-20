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

    // GET: api/client/filtered?name=John&email=test@email.com
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
            return NotFound();
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

        try
        {
            var id = _clientService.Create(name, email, birthDate);

            Logger.GetInstance().Log($"[ClientController] Client created successfully. id={id}");

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
        catch (Exception ex)
        {
            Logger.GetInstance().Log($"[ClientController] Error creating client. {ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/client
    [HttpPut]
    public IActionResult Update([FromBody] UpdateClientRequest clientUpdated)
    {
        Logger.GetInstance().Log($"[ClientController] Update called. id={clientUpdated.Id}");

        var client = new Client(
            clientUpdated.Name,
            clientUpdated.Email,
            clientUpdated.BirthDate
        );        

        var updated = _clientService.Update(client);

        if (!updated)
        {
            Logger.GetInstance().Log($"[ClientController] Client not found for update. id={client.Id}");
            return NotFound();
        }

        Logger.GetInstance().Log($"[ClientController] Client updated successfully. id={client.Id}");
        return NoContent();
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
            return NotFound();
        }

        Logger.GetInstance().Log($"[ClientController] Client deleted successfully. id={id}");
        return NoContent();
    }
}