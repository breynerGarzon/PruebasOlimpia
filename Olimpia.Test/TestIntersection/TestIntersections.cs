using Olimpia.Business.Caculate;
using Olimpia.Business.Model;
using Xunit;

namespace Olimpia.Test.TestIntersection
{
    public class TestIntersections
    {
        [Theory]
      //[InlineData(X, Y, R, X, Y, R, true)]
        [InlineData(6, 2, 3, 11, 2, 3, true)]
        [InlineData(6, 2, 2, 5, 10, 2, false)]
        [InlineData(6, 2, 2, 10, 5, 4, true)]
        [InlineData(6, 2, 2, 10, 5, 2, false)]
        [InlineData(2, 4, 3, 6, 2, 2, true)]
        [InlineData(2, 4, 1, 6, 2, 2, false)]
        public void TestIntersection(int circleX1, int circleY1, int circleRadio1, int circleX2, int circleY2, int circleRadio2, bool expected)
        {
            Circle circle1 = new Circle() { X = circleX1, Y = circleY1, Radio = circleRadio1 };
            Circle circle2 = new Circle() { X = circleX2, Y = circleY2, Radio = circleRadio2 };
            CalculateIntersection newIntersection = new CalculateIntersection(circle1, circle2);
            bool result = newIntersection.GetStatusIntersection();
            Assert.True(expected == result);
        }
    }
}