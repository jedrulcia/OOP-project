using System;

namespace BattleForMiddleEarth
{
    class Event
    {
        private readonly int heal;
        private readonly int damage;

        public int Heal
        {
            get
            {
                return heal;
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public static void HealForcesEvent(Warrior[] warriors)
        {
            for (int i = 0; i < warriors.Length; i++)
            {
                if (warriors[i].IsAlive == true)
                {
                    warriors[i].health += 20;
                    Tools.ColorfulWriteLine($"***{warriors[i].name} HAS BEEN HEALED FOR 20 HEALTH***", ConsoleColor.Yellow);
                    Tools.ColorfulWriteLine($"***CURRENT HEALTH OF {warriors[i].name} IS {warriors[i].health}***", ConsoleColor.Yellow);
                }
            }
            Tools.ColorfulWriteLine("------------------------------------------------------------------------", ConsoleColor.Yellow);
        }
        public static void DamageForcesEvent(Warrior[] warriors)
        {
            for (int i = 0; i < warriors.Length; i++)
            {
                if (warriors[i].IsAlive == true)
                {
                    warriors[i].health -= 20;
                    Tools.ColorfulWriteLine($"***{warriors[i].name} HAS BEEN DAMAGED FOR 20 HEALTH***", ConsoleColor.Yellow);
                    Tools.ColorfulWriteLine($"***CURRENT HEALTH OF {warriors[i].name} IS {warriors[i].health}***", ConsoleColor.Yellow);
                    if (warriors[i].health <= 0)
                    {
                        warriors[i].isAlive = false;
                        Tools.ColorfulWriteLine($"***{warriors[i].name} IS DEAD!***", ConsoleColor.Yellow);
                    }
                }
            }
            Tools.ColorfulWriteLine("------------------------------------------------------------------------", ConsoleColor.Yellow);
        }
    }
}
