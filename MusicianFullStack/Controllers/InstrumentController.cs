using Microsoft.AspNetCore.Mvc;
using MusicianFullStack.Models;
using MusicianFullStack.Repositories;

namespace MusicianFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentRepository _instrumentRepository;

        public InstrumentController(IInstrumentRepository instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instrumentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_instrumentRepository.GetById(id));
        }

        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return Ok(_instrumentRepository.GetAll());
            }

            return Ok(_instrumentRepository.Search(q));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _instrumentRepository.Update(instrument);
            return NoContent();
        }
    }
}
