using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Inventory;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.DeadCharacter);
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotHealEnemy);
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}