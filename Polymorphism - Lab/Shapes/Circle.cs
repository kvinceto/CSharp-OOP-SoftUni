namespace Shapes
{
    using System;
    using System.Text;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius) : base()
        {
            this.radius = radius;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            double thickness = 0.4;
            char symbol = '*';
            double rIn = radius - thickness, rOut = radius + thickness;
            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append(symbol);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
