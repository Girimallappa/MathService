using MathService.Models;
using System;

namespace MathService.BusinessLogic
{
    /// <summary>
    /// Determines the type of triangle
    /// </summary>
    public class TriangleTypeChecker : ITriangleTypeChecker
    {
        #region Member variables
        private readonly ITriangleValidator _triangleValidator;
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="triangleValidator">Validator for triangle data</param>
        public TriangleTypeChecker(ITriangleValidator triangleValidator)
        {
            _triangleValidator = triangleValidator;
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangleDto"></param>
        /// <returns></returns>
        public Response DetermineTriangleType(TriangleDto triangleDto)
        {
            if (!_triangleValidator.IsTriangleValid(triangleDto))
            {
                return new FailResponse("Sides don't form a triangle");
            }

            if (triangleDto.A == triangleDto.B && triangleDto.B == triangleDto.C)
            {
                return CreateSuccessResponse(TriangleType.Equilateral);
            }
            else if (triangleDto.A == triangleDto.B || triangleDto.B == triangleDto.C || triangleDto.A == triangleDto.C)
            {
                return CreateSuccessResponse(TriangleType.Isosceles);
            }
            else if (DoesSatisfyPythagoras(triangleDto.A, triangleDto.B, triangleDto.C) ||
                DoesSatisfyPythagoras(triangleDto.B, triangleDto.A, triangleDto.C) ||
                DoesSatisfyPythagoras(triangleDto.C, triangleDto.A, triangleDto.B))
            {
                return CreateSuccessResponse(TriangleType.RightAngled);
            }
            else
            {
                return CreateSuccessResponse(TriangleType.Scalene);
            }
        }

        #endregion

        #region Private Members
        
        /// <summary>
        /// Creates a succesful response for a triangle type
        /// </summary>
        /// <param name="triangleType">type of triangle</param>
        /// <returns></returns>
        private Response CreateSuccessResponse(TriangleType triangleType)
        {
            return new SuccessResponse(triangleType);
        }

        /// <summary>
        /// Floating point comparison for 2 decimals
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool AlmostEqual(decimal a, decimal b)
        {
            var threshold = 0.00001m;
            var diff = Math.Abs(a - b);

            return diff < threshold;
        }

        /// <summary>
        /// Checks if 3 sides satisfy Pythagoras theorem
        /// </summary>
        /// <param name="s1">Side 1</param>
        /// <param name="s2">Side 2</param>
        /// <param name="s3">Side 3</param>
        /// <returns></returns>
        private bool DoesSatisfyPythagoras(decimal s1, decimal s2, decimal s3) => AlmostEqual(s1 * s1, ((s2 * s2) + (s3 * s3))); 

        #endregion
    }

    /// <summary>
    /// Interface 
    /// </summary>
    public interface ITriangleTypeChecker
    {
        /// <summary>
        /// Determine triangle type for given sides
        /// </summary>
        /// <param name="triangleDto"></param>
        /// <returns></returns>
        Response DetermineTriangleType(TriangleDto triangleDto);
    }
}
