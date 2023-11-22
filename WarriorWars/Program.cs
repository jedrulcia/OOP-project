using BattleForMiddleEarth;

namespace BattleForMiddleEarth
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            Warrior humanOne = new Warrior("Aragorn", Enum.Faction.Human);
            Warrior humanTwo = new Warrior("Eomer", Enum.Faction.Human);
            Warrior humanThree = new Warrior("Faramir", Enum.Faction.Human);

            Warrior dwarfOne = new Warrior("Gimli", Enum.Faction.Dwarf);
            Warrior dwarfTwo = new Warrior("Thorin", Enum.Faction.Dwarf);
            Warrior dwarfThree = new Warrior("Kili", Enum.Faction.Dwarf);

            Warrior elfOne = new Warrior("Legolas", Enum.Faction.Elf);
            Warrior elfTwo = new Warrior("Elrond", Enum.Faction.Elf);
            Warrior elfThree = new Warrior("Arwena", Enum.Faction.Elf);

            Warrior orcOne = new Warrior("Gothmog", Enum.Faction.Orc);
            Warrior orcTwo = new Warrior("Shagrat", Enum.Faction.Orc);
            Warrior orcThree = new Warrior("Gorbag", Enum.Faction.Orc);

            Warrior goblinOne = new Warrior("Horde of Goblins from Moria", Enum.Faction.Goblin);
            Warrior goblinTwo = new Warrior("Horde of Goblins from High Pass", Enum.Faction.Goblin);
            Warrior goblinThree = new Warrior("Horde of Goblins from Misty Mountains", Enum.Faction.Goblin);

            Warrior urukhaiOne = new Warrior("Lurtz", Enum.Faction.Urukhai);
            Warrior urukhaiTwo = new Warrior("Ugluk", Enum.Faction.Urukhai);
            Warrior urukhaiThree = new Warrior("Mauhur", Enum.Faction.Urukhai);

            Warrior[] lightWarriors = {humanOne, humanTwo, humanThree, dwarfOne, dwarfTwo, dwarfThree, elfOne, elfTwo, elfThree};
            Warrior[] darkWarriors = {orcOne, orcTwo, orcThree, goblinOne, goblinTwo, goblinThree, urukhaiOne, urukhaiTwo, urukhaiThree};

            Warrior[] fightingLightWarriors = Warrior.DrawingTeam(lightWarriors);
            Warrior[] fightingDarkWarriors = Warrior.DrawingTeam(darkWarriors);

            int holder, lightHolder, darkHolder;
            int deadDarkCounter = 0;
            int deadLightCounter = 0;
            while (deadDarkCounter != 3 && deadLightCounter != 3)
            {
                if (random.Next(0, 100) > 95)
                {
                    Thread.Sleep(800);
                    Warrior.RandomEvent(fightingDarkWarriors, fightingLightWarriors);
                }
                holder = random.Next(0, 10);
                lightHolder = random.Next(0, fightingLightWarriors.Length);
                darkHolder = random.Next(0, fightingDarkWarriors.Length);
                if (holder > 5)
                {
                    if (fightingDarkWarriors[darkHolder].IsAlive && fightingLightWarriors[lightHolder].IsAlive)
                    {
                        fightingLightWarriors[lightHolder].Attack(fightingDarkWarriors[darkHolder], ConsoleColor.Blue);
                        if (fightingDarkWarriors[darkHolder].IsAlive == false)
                        {
                            deadDarkCounter++;
                        }
                        Thread.Sleep(800);
                    }
                }
                else
                {
                    if (fightingDarkWarriors[darkHolder].IsAlive && fightingLightWarriors[lightHolder].IsAlive)
                    {
                        fightingDarkWarriors[darkHolder].Attack(fightingLightWarriors[lightHolder], ConsoleColor.Red);
                        if (fightingLightWarriors[lightHolder].IsAlive == false)
                        {
                            deadLightCounter++;
                        }
                        Thread.Sleep(800);
                    }
                }
            }
            Warrior.BattleResult(deadLightCounter, deadDarkCounter);            
        }
    }
}