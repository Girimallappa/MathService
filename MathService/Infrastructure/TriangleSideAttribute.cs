using System.ComponentModel.DataAnnotations;

namespace MathService.Infrastructure
{
    /// <summary>
    /// Attribute to validate each triangle side
    /// </summary>
    public class TriangleSideAttribute : ValidationAttribute
    {

        #region Private Members
        
        private string GetErrorMessage(decimal side) =>
            $"{side} is not a valid length for side of a triangle.";

        #endregion

        #region validation members
        /// <summary>
        /// Validate the side
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var side = (decimal)value;

            if (side <= 0)
            {
                return new ValidationResult(GetErrorMessage(side));
            }

            return ValidationResult.Success;
        } 
        #endregion
    }
}
