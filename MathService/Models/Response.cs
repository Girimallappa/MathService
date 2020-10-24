namespace MathService.Models
{
    /// <summary>
    /// Base class response
    /// </summary>
    public abstract class Response
    {
        #region Public properties

        /// <summary>
        /// Status of the response
        /// </summary>
        public bool Status { get; protected set; }

        /// <summary>
        /// Response Message
        /// </summary>
        public string Message { get; protected set; } 

        #endregion
    }

    /// <summary>
    /// Failure response
    /// </summary>
    public class FailResponse: Response
    {
        #region Public properties

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to create failure response
        /// </summary>
        /// <param name="error"></param>
        /// <param name="message"></param>
        public FailResponse(string error, string message = "")
        {
            Status = false;
            Message = message;
            ErrorMessage = error;
        } 

        #endregion
    }

    /// <summary>
    /// Successful response
    /// </summary>
    public class SuccessResponse : Response
    {
        #region Public Properties
        
        public string TriangleDescription { get; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor to Create successful response
        /// </summary>
        /// <param name="triangleType"></param>
        /// <param name="message"></param>
        public SuccessResponse(TriangleType triangleType, string message = "")
        {
            Status = true;
            Message = message;
            TriangleDescription = GetTriangleDescription(triangleType);
        } 

        #endregion

        #region Private methods

        /// <summary>
        /// Description for triangle based on type
        /// </summary>
        /// <param name="triangleType"></param>
        /// <returns></returns>
        private string GetTriangleDescription(TriangleType triangleType)
        {
            return triangleType switch
            {
                var x when
                    x == TriangleType.Equilateral ||
                    x == TriangleType.Isosceles ||
                    x == TriangleType.Scalene => $"{triangleType} triangle",

                TriangleType.RightAngled => "Right Angled triangle",               
            };
        } 

        #endregion
    }

}
