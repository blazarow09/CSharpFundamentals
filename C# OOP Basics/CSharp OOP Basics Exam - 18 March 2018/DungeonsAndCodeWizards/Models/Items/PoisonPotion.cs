using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int hitPointsDamaged = 20;

        public PoisonPotion() : base(5)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health = Math.Max(0, character.Health - hitPointsDamaged);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
