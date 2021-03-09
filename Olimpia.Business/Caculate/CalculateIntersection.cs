using System;
using Olimpia.Business.Model;

namespace Olimpia.Business.Caculate
{
    public class CalculateIntersection
    {
        private bool IsInIntersection { get; set; }
        public CalculateIntersection(Circle circle1, Circle circle2)
        {
            int sum = this.CalculateRadiusSum(circle1.Radio, circle2.Radio);
            int substrac = this.CalculateRadiusSubtraction(circle1.Radio, circle2.Radio);
            double distance = this.CalculateDistance(circle1, circle2);
            this.CalculatePossibleIntersection(substrac, distance, sum);
        }

        private int CalculateRadiusSum(int radio1, int radio2)
        {
            return radio1 + radio2;
        }

        private double CalculateDistance(Circle circle1, Circle circle2)
        {
            int distanceInXbase = circle1.X - circle2.X;
            double distanceInX = Math.Pow(distanceInXbase, 2);
            int distanceInYbase = circle1.Y - circle2.Y;
            double distanceInY = Math.Pow(distanceInYbase, 2);
            return Math.Sqrt(distanceInX + distanceInY);
        }

        private int CalculateRadiusSubtraction(int radio1, int radio2)
        {
            return Math.Abs(radio1 - radio2);
        }

        private void CalculatePossibleIntersection(int radiusSubtraction, double differenceBetweenPoints, int radiusSum)
        {
            if (radiusSubtraction <= differenceBetweenPoints && differenceBetweenPoints <= radiusSum)
            {
                this.IsInIntersection = true;
            }
        }

        public bool GetStatusIntersection()
        {
            return this.IsInIntersection;
        }
    }
}