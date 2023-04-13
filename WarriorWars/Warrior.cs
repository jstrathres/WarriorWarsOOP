using WarriorWars.Enum; //auto added
using WarriorWars.Equipment;

namespace WarriorWars
{
    class Warrior
    {
        //private cannot be accessed outside of class, no need to be public
        private const int GOOD_GUY_STARTING_HEALTH = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;

        //yellow due to enum class
        private readonly Faction FACTION;

        //properties of warrior
        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        //seperate classes
        private Weapon weapon;
        private Armor armor;


        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            this.isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            //critical damange multiplier
            bool isCritical= new Random().NextDouble() < 0.1;

            if (isCritical)
            {
                damage *= 3;
                Tools.ColorfulWriteLine($"{name} performs a critical hit of {damage} points to {enemy.name}, " +
                    $"{enemy.name} has {enemy.health} health left!", ConsoleColor.Red);
            }

            enemy.health -= damage;

            AttackResult(enemy, damage);
            Thread.Sleep(300);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is victorious!", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine($"{name} has struck {enemy.name} with {damage} points of damage, {enemy.name} has {enemy.health} health left!");
            }
        }
    }
}
