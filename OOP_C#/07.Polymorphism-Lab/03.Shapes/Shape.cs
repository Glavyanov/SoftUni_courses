using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {

        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString().TrimEnd();
        }
    }
}
