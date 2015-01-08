using System.Collections.Generic;
using CodeReviewTool.Models;
using CodeReviewTool.Repositories;

namespace CodeReviewTool.Service
{
    public interface ITeamService
    {
        TeamMember GetTeamMember(string id);
        List<TeamMember> GetAllTeamMembers();
        void StoreTeamMember(string key, string value);
    }
    
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService() : this(new TeamRepository())
        {
        }

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        
        public TeamMember GetTeamMember(string id)
        {
            return _teamRepository.GetTeamMember(id);
        }

        public List<TeamMember> GetAllTeamMembers()
        {
            return _teamRepository.GetAllTeamMembers();
        }

        public void StoreTeamMember(string key, string value)
        {
            _teamRepository.StoreTeamMember(key, value);
        }
    }
}