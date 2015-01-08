using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReviewTool.Models;
using CodeReviewTool.Repositories;
using Moq;
using NUnit.Framework;
using Raven.Client;

namespace CodeReviewTool.Tests.TeamTests
{
    [TestFixture]


    public class TeamRepositoryTests
    {
        private Mock<IDocumentSession> _documentSessionMock;
        private TeamRepository _teamRepository;

        [SetUp]
        public void Setup()
        {
            _documentSessionMock = new Mock<IDocumentSession>();
            _documentSessionMock.Setup(r => r.Store(It.IsAny<TeamMember>()));
            _documentSessionMock.Setup(r => r.SaveChanges());

            _teamRepository = new TeamRepository(_documentSessionMock.Object);
        }

        [Test]
        public void ShouldStoreMember()
        {
            _teamRepository.StoreTeamMember("123", "nick");
            _documentSessionMock.Verify(r=>r.Store(It.IsAny<TeamMember>()), Times.Once);
            _documentSessionMock.Verify(r=>r.SaveChanges(), Times.Once);
        }
    }
}
