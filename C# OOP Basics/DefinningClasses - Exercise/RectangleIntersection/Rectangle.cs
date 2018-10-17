namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public string Id
        {
            get { return id; }
        }

        public Rectangle()
        {
        }

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        public bool IsIntersects(Rectangle n)
        {
            if ((n.y >= this.y && n.y - n.height <= this.y && n.x <= this.x && n.x + n.width >= this.x) ||
            (n.y >= this.y && n.y - n.height <= this.y && n.x >= this.x && n.x <= this.x + this.width) ||
            (n.y <= this.y && n.y >= this.y - this.height && n.x <= this.x && n.x + n.width >= this.x) ||
            (n.y <= this.y && n.y >= this.y - this.height && n.x >= this.x && n.x <= this.x + this.width))
            {
                return true;
            }

            return false;
        }
    }
}