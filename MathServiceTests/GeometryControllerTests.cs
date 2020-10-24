using Autofac.Extras.Moq;
using MathService.BusinessLogic;
using MathService.Controllers;
using MathService.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static MathServiceTests.Shared;

namespace MathServiceTests
{
    /// <summary>
    /// Tests for the Controller
    /// </summary>
    public class GeometryControllerTests
    {
        [Fact]
        public void DetermineTriangleType_ShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITriangleTypeChecker>()
                    .Setup(x => x.DetermineTriangleType(probableTriangles["NotATriangle"]))
                    .Returns(new FailResponse("Sides dont form a triangle"));

                var triangleTypeChecker = mock.Create<GeometryController>();

                BadRequestObjectResult response = (BadRequestObjectResult)triangleTypeChecker.DetermineTriangleType(probableTriangles["NotATriangle"]);

                Assert.True(response.StatusCode == 400);

            }

        }

        [Fact]
        public void DetermineTriangleType_ShouldPass()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITriangleTypeChecker>()
                    .Setup(x => x.DetermineTriangleType(probableTriangles["Equilateral"]))
                    .Returns(new SuccessResponse(TriangleType.Equilateral));

                var triangleTypeChecker = mock.Create<GeometryController>();

                OkObjectResult response = (OkObjectResult)triangleTypeChecker.DetermineTriangleType(probableTriangles["Equilateral"]);

                Assert.True(response.StatusCode == 200);

            }

        }
    }
}
