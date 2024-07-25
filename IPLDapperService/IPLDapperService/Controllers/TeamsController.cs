using IPLDapperService.Dtos;
using IPLDapperService.Repos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPLDapperService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepo _teamRepo;

        public TeamsController(ITeamRepo teamRepo)
        {
            _teamRepo=teamRepo;
        }
        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                var teams = await _teamRepo.GetTeams();
                return Ok(teams);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);

            }
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}",Name ="TeamById")]
        public async Task<IActionResult> Get(int id)
        {
            try {
                var team = await _teamRepo.GetTeamById(id);
                if(team == null)
                {
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        //// POST api/<TeamsController>
        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamCreateUpdateDto team)
        {
            try { 
                var createdTeam=await _teamRepo.CreateTeam(team);   
                return Ok(createdTeam);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        //// Post api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, TeamCreateUpdateDto team)
        {
            try
            {
               var searchTeam=await _teamRepo.GetTeamById(id);
                if (searchTeam == null)
                {                  
                    return NotFound();
                }
                await _teamRepo.UpdateTeam(id, team);
                return NoContent();

            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        //// DELETE api/<TeamsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
