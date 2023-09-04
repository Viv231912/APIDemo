using APIDemo.Services.SuperHeroServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly ISuperHeroService _superHeroService;
        //Constructor
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        //first method IActionResult return status code ex: "404 Not Found"
        [HttpGet] // need this when using swager
        //first Get Call
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();

        }
        //Return single hero
        [HttpGet("{id}")] //HttpGet +  [Route("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            //use not found status code
            if (result == null) return NotFound("Sorry, this hero doesn't exist.");

            return Ok(result);

        }

        //Add a hero
        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result= await _superHeroService.AddHero(hero);
            
            return Ok(result);

        }

        //Edit a hero
        [HttpPut("{id}")] //HttpGet +  [Route("{id}")]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result == null) return NotFound("Hero not found.");



            return Ok(result);

        }


        //Delete a hero
        [HttpDelete("{id}")] //HttpGet +  [Route("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result == null) return NotFound("Hero not found"); 
            return Ok(result);



        }

    }
}

