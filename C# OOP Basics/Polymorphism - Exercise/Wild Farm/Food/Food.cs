namespace _03.Wild_Farm
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
       
        public int Quantity { get; set; }
    }
}
