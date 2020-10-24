using MathService.Infrastructure;

namespace MathService.Models
{
    /// <summary>
    /// Dto for triangle data
    /// </summary>
    public class TriangleDto
    {
        /// <summary>
        /// Side A
        /// </summary>
        [TriangleSide]
        public decimal A { get; set; }

        /// <summary>
        /// Side B
        /// </summary>
        [TriangleSide]
        public decimal B { get; set; }

        /// <summary>
        /// Side C
        /// </summary>
        [TriangleSide]
        public decimal C { get; set; }        
    }
}
