namespace ClassBoxDataValidation
{
    using System;

    public class Box
    {
        private double volume;
        private double surfaceArea;
        private double lateralSurfaceArea;
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public void CalculateLateralSurfaceArea(double length, double width, double height)
        {
            this.lateralSurfaceArea = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public void CalculateSurfaceArea(double length, double width, double height)
        {
            this.surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public void CalculateVolume(double length, double width, double height)
        {
            this.volume = (this.Length * this.Width * this.Height);
        }

        public override string ToString()
        {
            return $"Surface Area - {this.surfaceArea:f2}\n" +
                $"Lateral Surface Area - {this.lateralSurfaceArea:f2}\n" +
                $"Volume - {this.volume:f2}";
        }
    }
}