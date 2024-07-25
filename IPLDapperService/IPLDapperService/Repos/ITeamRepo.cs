using IPLDapperService.Dtos;
using IPLDapperService.Models;

namespace IPLDapperService.Repos
{
    public interface ITeamRepo
    {
        public Task<IEnumerable<Team>> GetTeams();
        public Task<Team> GetTeamById(int id);
        public Task<Team> CreateTeam(TeamCreateUpdateDto team);
        public Task UpdateTeam(int id,TeamCreateUpdateDto team);
       // public Task DeleteTeam(int id);
       
    }
}

