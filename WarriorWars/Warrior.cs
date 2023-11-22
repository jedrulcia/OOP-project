using BattleForMiddleEarth.Equipment;
using BattleForMiddleEarth.Enum;
using System;

namespace BattleForMiddleEarth
{
    class Warrior
    {
        private const int HUMAN_STARTING_HEALTH = 80;
        private const int DWARF_STARTING_HEALTH = 120;
        private const int ELF_STARTING_HEALTH = 100;
        private const int ORC_STARTING_HEALTH = 100;
        private const int GOBLIN_STARTING_HEALTH = 80;
        private const int URUKHAI_STARTING_HEALTH = 120;

        private readonly Faction FACTION;

        public int health;
        public string name;
        public bool isAlive;

        private Weapon weapon;
        private Armor armor;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }
        public Warrior(string name, Faction faction)
        {
            this.name = name;
            this.FACTION = faction;
            this.isAlive = true;

            switch (faction)
            {
                case Faction.Human:
                    weapon = new Weapon(Weapons.Sword);
                    armor = new Armor(Armors.LightArmor);
                    health = HUMAN_STARTING_HEALTH;
                    break;
                case Faction.Dwarf:
                    weapon = new Weapon(Weapons.Axe);
                    armor = new Armor(Armors.HeavyArmor);
                    health = DWARF_STARTING_HEALTH;
                    break;
                case Faction.Elf:
                    weapon = new Weapon(Weapons.Bow);
                    armor = new Armor(Armors.Mithril);
                    health = ELF_STARTING_HEALTH;
                    break;
                case Faction.Orc:
                    weapon = new Weapon(Weapons.Flail);
                    armor = new Armor(Armors.LightArmor);
                    health = ORC_STARTING_HEALTH;
                    break;
                case Faction.Goblin:
                    weapon = new Weapon(Weapons.Dagger);
                    armor = new Armor(Armors.Armorless);
                    health = GOBLIN_STARTING_HEALTH;
                    break;
                case Faction.Urukhai:
                    weapon = new Weapon(Weapons.Sword);
                    armor = new Armor(Armors.HeavyArmor);
                    health = URUKHAI_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }
        public static Warrior[] DrawingTeam(Warrior[] warriors)
        {
            Random random = new Random();

            Warrior[] fightingWarriors = new Warrior[3];
            int holder;
            for (int i = 0; i < 3; i++)
            {
                holder = random.Next(0, warriors.Length - 1);
                if (warriors[holder] != null)
                {
                    Warrior dupa = warriors[holder];
                    fightingWarriors[i] = warriors[holder];
                    warriors[holder] = null;
                }
                else
                {
                    i--;
                }
            }
            return fightingWarriors;
        }
        public void Attack(Warrior enemy, ConsoleColor color)
        {
            Random random = new Random();
            int damage = (weapon.Damage / enemy.armor.ArmorPoints) * weapon.Speed;
            if (random.Next(1, 100/weapon.CriticalChance) == 1)
            {
                Tools.ColorfulWriteLine("***CRITICAL HIT!***", ConsoleColor.Yellow);
                damage = damage * 2;
            }
            enemy.health -= damage;
            AttackResult(enemy, damage, color);
        }
        private void AttackResult(Warrior enemy, int damage, ConsoleColor color)
        {
            Tools.ColorfulWriteLine($"{name} attacked {enemy.name}.", color);
            Tools.ColorfulWriteLine($"{damage} damage was inflicted to {enemy.name}.", color);
            Tools.ColorfulWriteLine($"Remaining health of {enemy.name} is {enemy.health}", color);
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"***{enemy.name} IS DEAD!***", ConsoleColor.Yellow);
            }
            Tools.ColorfulWriteLine("------------------------------------------------------------------------", ConsoleColor.Yellow);
        }
        public static void BattleResult(int deadLightCounter, int deadDarkCounter)
        {
            if (deadLightCounter != 3)
            {
                Tools.ColorfulWriteLine("The forces of light are victorious!", ConsoleColor.Green);
            }
            else
            {
                Tools.ColorfulWriteLine("The forces of dark have won!", ConsoleColor.Green);
            }
        }
        public static void RandomEvent(Warrior[] fightingLightWarriors, Warrior[] fightingDarkWarriors)
        {
            Random random = new Random();
            int holder = random.Next(1, 4);

            switch (holder)
            {
                case 1:
                    Event.HealForcesEvent(fightingLightWarriors);
                    break;
                case 2:
                    Event.HealForcesEvent(fightingDarkWarriors);
                    break;
                case 3:
                    Event.DamageForcesEvent(fightingLightWarriors);
                    break;
                case 4:
                    Event.DamageForcesEvent(fightingDarkWarriors);
                    break;
                default:
                    break;
            }
        }
    }
}
