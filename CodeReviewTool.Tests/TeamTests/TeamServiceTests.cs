using System;
using CodeReviewTool.Models;
using CodeReviewTool.Repositories;
using CodeReviewTool.Service;
using Moq;
using NUnit.Framework;

namespace CodeReviewTool.Tests.TeamTests
{
    [TestFixture]

    public class TeamServiceTests
    {
        private TeamService _teamService;
        private Mock<ITeamRepository> _teamRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _teamRepositoryMock = new Mock<ITeamRepository>();
            _teamRepositoryMock.Setup(r => r.GetTeamMember(It.IsAny<string>())).Returns(new TeamMember());

            _teamService = new TeamService(_teamRepositoryMock.Object);

        }

        [Test]
        public void ShouldGetTeamMember()
        {
            _teamService.GetTeamMember("1");
            _teamRepositoryMock.Verify(x => x.GetTeamMember(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShouldGetAllTeamMembers()
        {
            _teamService.GetAllTeamMembers();
            _teamRepositoryMock.Verify(x=>x.GetAllTeamMembers(), Times.Once);
        }
    }
}
