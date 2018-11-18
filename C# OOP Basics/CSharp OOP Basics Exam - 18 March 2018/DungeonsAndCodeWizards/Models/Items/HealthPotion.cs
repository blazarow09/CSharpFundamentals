using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
{
    public class HealthPotion : Item
    {
        private const int hitPointsRestored = 20;

        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += hitPointsRestored;
        }
    }
}