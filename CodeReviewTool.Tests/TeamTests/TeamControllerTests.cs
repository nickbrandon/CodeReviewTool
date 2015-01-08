using System.Collections.Generic;
using CodeReviewTool.Controllers;
using CodeReviewTool.Models;
using CodeReviewTool.Service;
using Moq;
using NUnit.Framework;


namespace CodeReviewTool.Tests.TeamTests
{
    [TestFixture]

    public class TeamControllerTests
    {
        //inject into the teams controller

        private Mock<ITeamService> _teamServiceMock;
        private TeamController _teamController;

        [SetUp]
        public void Setup()
        {
            _teamServiceMock = new Mock<ITeamService>();
            _teamServiceMock.Setup(t => t.GetTeamMember(It.IsAny<string>())).Returns(new TeamMember());
            _teamServiceMock.Setup(t => t.GetAllTeamMembers()).Returns(new List<TeamMember>());

            _teamController = new TeamController(_teamServiceMock.Object);
        }

        [Test]
        public void ShouldGetMember()
        {
            _teamController.GetMember("1");
            _teamServiceMock.Verify(t=>t.GetTeamMember(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShouldGetAllMembers()
        {
            _teamController.GetAll();
            _teamServiceMock.Verify(t => t.GetAllTeamMembers(), Times.Once);
        }
    }
}
