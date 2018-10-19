namespace ClassBox
{
    public class Box
    {
        private double volume;
        private double surfaceArea;
        private double lateralSurfaceArea;

        public Box()
        {
        }

        public void CalculateLateralSurfaceArea(double length, double width, double height)
        {
            this.lateralSurfaceArea = (2 * length * height) + (2 * width * height);
        }

        public void CalculateSurfaceArea(double length, double width, double height)
        {
            this.surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
        }

        public void CalculateVolume(double length, double width, double height)
        {
            this.volume = (length * width * height);
        }

        public override string ToString()
        {
            return $"Surface Area - {this.surfaceArea:f2}\n" +
                $"Lateral Surface Area - {this.lateralSurfaceArea:f2}\n" +
                $"Volume - {this.volume:f2}";
        }
    }
}