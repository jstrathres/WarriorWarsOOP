using WarriorWars.Enum;


namespace WarriorWars.Equipment
{
    class Armor
    {
        private int armorPoints;
        private int GOOD_GUY_ARMOR = 5;
        private int BAD_GUY_ARMOR = 5;

        public int ArmorPoints
        {
            get
            {
                return armorPoints;
            }
        }


        public Armor(Faction faction)
        {
            switch (faction)
            {
                case Faction.GoodGuy:
                    armorPoints = GOOD_GUY_ARMOR;
                    break;
                case Faction.BadGuy:
                    armorPoints = BAD_GUY_ARMOR;
                    break;
                default:
                    break;
            }
        }
    }
}
