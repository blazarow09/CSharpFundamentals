﻿using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Inventory;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotAttackSelf);
            }

            this.EnsureNotFriendlyFire(character);

            character.TakeDamage(this.AbilityPoints);
        }

        private void EnsureNotFriendlyFire(Character character)
        {
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
        }
    }
}