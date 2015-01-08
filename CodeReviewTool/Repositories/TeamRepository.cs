using System;
using System.Collections.Generic;
using CodeReviewTool.Models;
using Raven.Client;
using Raven.Client.Document;

namespace CodeReviewTool.Repositories
{
    public interface ITeamRepository
    {
        TeamMember GetTeamMember(string id);
        List<TeamMember> GetAllTeamMembers();
        void StoreTeamMember(string key, string value);
    }

    public class TeamRepository : ITeamRepository
    {
        private readonly IDocumentSession _documentSession;

        public TeamRepository()
            : this(new DocumentStore
            {
                ConnectionStringName = "ravenDB"
            }.Initialize().OpenSession())
        {
        }

        public TeamRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }


        public TeamMember GetTeamMember(string id)
        {
            return _documentSession.Load<TeamMember>(id);
        }

        public List<TeamMember> GetAllTeamMembers()
        {
            throw new NotImplementedException();
        }

        public void StoreTeamMember(string key, string value)
        {
            var member = new TeamMember {Name = value};
            _documentSession.Store(member, key);
            _documentSession.SaveChanges();
        }
    }
}