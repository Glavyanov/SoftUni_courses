using System;

namespace _01.ClassBoxDataRetake
{
    public class Box
    {
        private const double MinValue = 0;
        private const string ErrorMessage = "cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Height {ErrorMessage}");
                }
                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Width {ErrorMessage}");
                }
                width = value;
            }
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Length {ErrorMessage}");
                }
                length = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
