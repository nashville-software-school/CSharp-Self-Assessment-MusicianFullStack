using Microsoft.AspNetCore.Mvc;
using MusicianFullStack.Repositories;

namespace MusicianFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyRepository _difficultyRepository;

        public DifficultyController(IDifficultyRepository difficultyRepository)
        {
            _difficultyRepository = difficultyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_difficultyRepository.GetAll());
        }
    }
}
