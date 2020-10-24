using Autofac.Extras.Moq;
using MathService.BusinessLogic;
using MathService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static MathServiceTests.Shared;

namespace MathServiceTests
{
    /// <summary>
    /// Bsuiness logic tests
    /// </summary>
    public class TriangleTypeCheckerTests
    {
        [Fact]
        public void DetermineTriangleType_ValidationShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITriangleValidator>()
                    .Setup(x => x.IsTriangleValid(probableTriangles["NotATriangle"]))
                    .Returns(false);

                var triangleTypeChecker = mock.Create<TriangleTypeChecker>();

                var response = triangleTypeChecker.DetermineTriangleType(probableTriangles["NotATriangle"]);

                Assert.False(response.Status);

            }
        }

        [Theory]
        [InlineData("Equilateral")]
        [InlineData("Isosceles")]
        [InlineData("RightAngled")]
        [InlineData("Scalene")]
        public void DetermineTriangleType_ShouldDetermineTringleType(string triangleType)
        {
            var triangleDto = probableTriangles[triangleType]; 

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITriangleValidator>()
                    .Setup(x => x.IsTriangleValid(triangleDto))
                    .Returns(true);

                var triangleTypeChecker = mock.Create<TriangleTypeChecker>();

                SuccessResponse response = triangleTypeChecker.DetermineTriangleType(triangleDto)
                    as SuccessResponse;

                Assert.True(response.Status);

                if (triangleType != TriangleType.RightAngled.ToString())
                {
                    Assert.Contains(triangleType, response.TriangleDescription);
                }
                else
                {
                    Assert.Equal("Right Angled triangle", response.TriangleDescription);
                }

            }
        }

       
    }
}
