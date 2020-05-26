using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;                   
        }
        public double Length 
        {
            get
            {
                return length;
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        private double CalculateSurfaceArea()
        {
            return 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Width * Height);
        }

        private double CalculateLateralSurfaceArea()
        {
            return 2 * (Length * Height) + 2 * (Width * Height);
        }

        private double CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
