namespace Shapes
{
    using System.Text;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width) : base()
        {
            this.height = height;
            this.width = width;
        }
        public override double CalculatePerimeter()
        {
            return 2 * height + 2 * width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < (int)height; i++)
            {
                for (int j = 0; j < (int)width; j++)
                {
                    if (i == 0 || i == (int)height - 1)
                    {
                        sb.Append("*");
                    }
                    else if (j == 0 || j == (int)width - 1)
                    {
                        sb.Append("*");
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
