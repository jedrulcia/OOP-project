using System.Security.Claims;
using BattleForMiddleEarth.Enum;

namespace BattleForMiddleEarth.Equipment
{
    class Weapon
    {

        private readonly int DAMAGE;
        private readonly int SPEED;
        private readonly int CRITICAL_CHANCE;

        public int Damage
        {
            get
            {
                return DAMAGE;
            }
        }
        public int Speed
        {
            get
            {
                return SPEED;
            }
        }
        public int CriticalChance
        {
            get 
            { 
                return CRITICAL_CHANCE; 
            }
        }

        public Weapon(Weapons weapons)
        {
            switch (weapons)
            {
                case Weapons.Sword:
                    DAMAGE = 12;
                    SPEED = 2;
                    CRITICAL_CHANCE = 20;
                    break;
                case Weapons.Bow:
                    DAMAGE = 24;
                    SPEED = 1;
                    CRITICAL_CHANCE = 50;
                    break;
                case Weapons.Dagger:
                    DAMAGE = 12;
                    SPEED = 3;
                    CRITICAL_CHANCE = 20;
                    break;
                case Weapons.Axe:
                    DAMAGE = 30;
                    SPEED = 1;
                    CRITICAL_CHANCE = 60;
                    break;
                case Weapons.Flail:
                    DAMAGE = 18;
                    SPEED = 3;
                    CRITICAL_CHANCE = 15;
                    break;
                default:
                    break;
            }
        }
    }
}
