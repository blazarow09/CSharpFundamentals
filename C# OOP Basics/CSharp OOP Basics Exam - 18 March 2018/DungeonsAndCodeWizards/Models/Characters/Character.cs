using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.Health= health;
            this.BaseArmor = baseArmor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            protected set
            {
                this.baseHealth = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = Math.Min(value, this.baseHealth);
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            protected set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = Math.Min(value, this.baseArmor);
            }
        }

        public double AbilityPoints
		{
			get
			{
				return abilityPoints;
			}
			protected set
			{
				this.abilityPoints = value;
			}
		}

        public Bag Bag { get; }

        public Faction Faction { get; }

        protected virtual double RestHealMultiplier => (double)1 / 5;

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.DeadCharacter);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var hitPointsLeft = hitPoints - this.Armor;

            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitPointsLeft);

            if(this.Health == 0)
            {
                IsAlive = false;
            }
        }

        public void Rest()
        {
            this.EnsureAlive();

            this.Health = Math.Min(this.Health + (this.BaseHealth * RestHealMultiplier), this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public override string ToString()
		{
			const string format = "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";

			var result = string.Format(format,
				this.Name,
				this.Health,
				this.BaseHealth,
				this.Armor,
				this.BaseArmor,
				this.IsAlive ? "Alive" : "Dead");

			return result;
		}
    }
}
