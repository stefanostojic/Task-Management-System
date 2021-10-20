using AutoMapper;
using FakeItEasy;
using System;
using System.Threading.Tasks;
using Task_Management_System.Controllers;
using Task_Management_System.Profiles;
using Task_Management_System.Services.ProjectService;
using Xunit;

namespace Tests
{
    public class ProjectControllerTests
    {
        [Fact]
        public async Task GetProjectById_Returns_A_Project()
        {
            // Arrange
            Guid projectId = Guid.NewGuid();
            var fakeProjectService = A.Fake<IProjectService>();
            var fakeResult = A.Dummy<Task_Management_System.Models.Project>();
            A.CallTo(() => fakeProjectService.GetByIdAsync(projectId)).Returns(Task.FromResult(fakeResult));
            var myProfile = new ProjectProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            var controller = new ProjectsController(fakeProjectService, mapper);

            // Act
            var actionResult = await controller.GetProjectById(projectId);

            // Assert
            //var result = actionResult.
        }
    }
}
