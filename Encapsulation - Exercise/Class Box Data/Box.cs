using System;

namespace Box
{

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0) throw new ArgumentException("Length cannot be zero or negative.");
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0) throw new AggregateException("Width cannot be zero or negative.");
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0) throw new ArgumentException("Height cannot be zero or negative.");
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}" + Environment.NewLine +
                   $"Lateral Surface Area - {this.LateralSurfaceArea():f2}" + Environment.NewLine + $"Volume - {this.Volume():f2}";

        }
    }
}
