using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHerosAPIDotNet7.Models;
using SuperHerosAPIDotNet7.Service.SuperHeroServices;

namespace SuperHerosAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
     
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return await _superHeroService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            
            var request = await _superHeroService.GetSingleHero(id);
            if (request == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(request);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero superHero)
        {
           var request = await _superHeroService.AddHero(superHero);
            if (request == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(request);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero superHero)
        {
            var request = await _superHeroService.UpdateHero(superHero);
            if (request == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(request);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var request = await _superHeroService.DeleteHero(id);
            if (request == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(request);
        }
    }
}
