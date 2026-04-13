using DR_rest.Models;
using DR_rest.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DR_rest.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MusicRecordsController : ControllerBase
{
    private readonly IMusicRecordRepository _repository;

    public MusicRecordsController(IMusicRecordRepository repository)
    {
        _repository = repository;
    }

    // GET api/musicrecords?title=...&artist=...
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<MusicRecord>> GetAll([FromQuery] string? title, [FromQuery] string? artist)
    {
        return Ok(_repository.GetAll(title, artist));
    }

    // POST api/musicrecords
    [HttpPost]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<MusicRecord> Add([FromBody] MusicRecord record)
    {
        if (string.IsNullOrWhiteSpace(record.Title) || string.IsNullOrWhiteSpace(record.Artist))
            return BadRequest("Title and Artist are required.");

        var created = _repository.Add(record);
        return CreatedAtAction(nameof(GetAll), new { }, created);
    }
}
