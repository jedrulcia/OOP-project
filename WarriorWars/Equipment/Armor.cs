using BattleForMiddleEarth.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace BattleForMiddleEarth.Equipment
{
    class Armor
    {
        public readonly int ARMOR_POINTS;

        public int ArmorPoints
        {
            get
            {
                return ARMOR_POINTS;
            }
        }

        public Armor (Armors armors)
        {
            switch (armors)
            {
                case Armors.Mithril:
                    ARMOR_POINTS = 4;
                    break;
                case Armors.HeavyArmor:
                    ARMOR_POINTS = 3;
                    break;
                case Armors.LightArmor:
                    ARMOR_POINTS = 2;
                    break;
                case Armors.Armorless:
                    ARMOR_POINTS = 1;
                    break;
                default:
                    break;
            }
        }
    }
}