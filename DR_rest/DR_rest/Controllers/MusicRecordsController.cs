using DR_rest.Models;
using DR_rest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DR_rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicRecordsController : ControllerBase
{
    private readonly IMusicRecordRepository _repository;

    public MusicRecordsController(IMusicRecordRepository repository)
    {
        _repository = repository;
    }

    // GET api/musicrecords
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<MusicRecord>> GetAll()
    {
        return Ok(_repository.GetAll());
    }
}
