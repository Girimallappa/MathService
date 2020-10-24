using MathService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathServiceTests
{
    public static class Shared
    {
        public static IDictionary<string, TriangleDto> probableTriangles = new Dictionary<string, TriangleDto>
        {
            ["Equilateral"] = new TriangleDto { A = 6, B = 6, C = 6 },
            ["Isosceles"] = new TriangleDto { A = 6, B = 6, C = 5 },
            ["RightAngled"] = new TriangleDto { A = 4, B = 3, C = 5 },
            ["Scalene"] = new TriangleDto { A = 6, B = 5, C = 4 },
            ["NotATriangle"] = new TriangleDto { A = 6, B = 2, C = 2 }
        };
    }
}
