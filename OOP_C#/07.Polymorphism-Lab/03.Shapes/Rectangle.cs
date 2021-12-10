using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DrawLine(this.Width, '*', '*'));
            for (int i = 1; i < this.Height - 1; i++)
            {
                sb.AppendLine(DrawLine(this.Width, '*', ' '));
            }
            sb.AppendLine(DrawLine(this.Width, '*', '*'));
            return sb.ToString().TrimEnd();
        }
        private string DrawLine(double width, char end, char mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(end);
            for (int i = 1; i < width - 1; i++)
            {
                sb.Append(mid);
            }
            sb.Append(end);
            return sb.ToString();
        }
    }
}
