using MathService.BusinessLogic;
using MathService.Models;
using Microsoft.AspNetCore.Mvc;


namespace MathService.Controllers
{
    /// <summary>
    /// Controller for geometric calculations
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeometryController : ControllerBase
    {
        #region Member variables
        private ITriangleTypeChecker _triangleTypeChecker;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="triangleTypeChecker">business logic</param>
        public GeometryController(ITriangleTypeChecker triangleTypeChecker)
        {
            _triangleTypeChecker = triangleTypeChecker;
        }

        #endregion

        #region Api methods
        /// <summary>
        /// Method to determine triangle type.
        /// </summary>
        /// <param name="triangle">Triangle data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult DetermineTriangleType([FromBody] TriangleDto triangle)
        {          

            //Determine the type of triangle
            var response = _triangleTypeChecker.DetermineTriangleType(triangle);

            //Failed response
            if (!response.Status)
            {
                return BadRequest(response);
            }

            //Successful response
            return Ok(response);
        } 
        #endregion
    }
}
