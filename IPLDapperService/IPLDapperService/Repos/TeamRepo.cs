using Dapper;
using IPLDapperService.Context;
using IPLDapperService.Dtos;
using IPLDapperService.Models;

namespace IPLDapperService.Repos
{
    public class TeamRepo : ITeamRepo
    {
        private readonly DapperContext _context;

        public TeamRepo(DapperContext context)
        {
            _context=context;
        }

        public async Task<Team> CreateTeam(TeamCreateUpdateDto
 team)
        {
            var query = "insert into Teams (Name,Slogan,City) values (@name,@slogan,@city)"
                + "select cast(Scope_Identity() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", team.Name);
            parameters.Add("@slogan", team.Slogan);
            parameters.Add("@city", team.City);
            using (var con=_context.CreateConnection())
            {
               var teamid= await con.ExecuteAsync(query, parameters);
                var createdTeam = new Team
                {
                    Id = teamid,
                    Name = team.Name,
                    City = team.City,
                    Slogan = team.Slogan
                };
                return createdTeam;
            }
        }

        public async Task<Team> GetTeamById(int id)
        {
            var query = "select * from Teams where Id=@Id";
            using (var con = _context.CreateConnection())
            {    var team=await con.QuerySingleOrDefaultAsync<Team>(query,new {id});
                return team;

            }
           
        }

       public async Task<IEnumerable<Team>> GetTeams()
        {
            var query = "select * from Teams";
            using(var con=_context.CreateConnection())
            {
                var teams= await con.QueryAsync<Team>(query);
                return teams.ToList();  
            }
        }

        public async Task UpdateTeam(int id, TeamCreateUpdateDto team)
        {
            var query = "update Teams set Name=@name,Slogan=@slogan,City=@city where Id=@id";
               
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@name", team.Name);
            parameters.Add("@slogan", team.Slogan);
            parameters.Add("@city", team.City);
            using (var con = _context.CreateConnection())
            {
               await con.ExecuteAsync(query, parameters);
            }
        }

       
    }
}
