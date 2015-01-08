using System.Collections.Generic;
using System.Web.Http;
using CodeReviewTool.Models;
using CodeReviewTool.Service;

namespace CodeReviewTool.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ITeamService _teamService;

        public TeamController() : this(new TeamService())
        {
        }

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public List<TeamMember> GetAll()
        {
            return _teamService.GetAllTeamMembers();
        }

        public TeamMember GetMember(string id)
        {
            return _teamService.GetTeamMember(id);
        }
        
        public void StoreTeamMember(string key, string value)
        {
            _teamService.StoreTeamMember(key, value);
        }
    }
}