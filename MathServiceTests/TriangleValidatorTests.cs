using MathService.Models;
using Xunit;
using static MathServiceTests.Shared;

namespace MathServiceTests
{
    /// <summary>
    /// Tests the validator
    /// </summary>
    public class TriangleValidatorTests
    {
        [Fact]
        public void IsTriangleValid_Fail()
        {
            var triangleValidator = new TriangleValidator();

            var status =  triangleValidator.IsTriangleValid(probableTriangles["NotATriangle"]);

            Assert.False(status);

        }

        [Fact]
        public void IsTriangleValid_Pass()
        {
            var triangleValidator = new TriangleValidator();

            var status = triangleValidator.IsTriangleValid(probableTriangles["Equilateral"]);

            Assert.True(status);

        }
    }
}
