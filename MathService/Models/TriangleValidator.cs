using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathService.Models
{
    /// <summary>
    /// Validates if 3 sides can form a triangle
    /// </summary>
    public class TriangleValidator: ITriangleValidator
    {
        /// <summary>
        /// Validation. Triangle is valid is sum of 2 sides is greater than the third side
        /// </summary>
        /// <returns></returns>
        public bool IsTriangleValid(TriangleDto t) => (t.A > 0 && t.B > 0 && t.C > 0) &&
            (t.A + t.B) >= t.C && (t.B + t.C) >= t.A && (t.C + t.A) >= t.B;
    }

    /// <summary>
    /// Validator interface
    /// </summary>
    public interface ITriangleValidator
    {
        public bool IsTriangleValid(TriangleDto t);
    }
}
