namespace DungeonsAndCodeWizards.Models.Inventory
{
    public class Satchel : Bag
    {
        private const int defaultCapacity = 20;

        public Satchel() : base(defaultCapacity)
        {
        }
    }
}