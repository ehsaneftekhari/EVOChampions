using EVOChampions.Managers;
using static System.Net.Mime.MediaTypeNames;

namespace EVOChampions.Games.GameApps
{
    public sealed class RoundPlayer : ParentChildrenKeeper
    {
        private int lastDamage;
        public string UserName => ((GameAppPlayer)Parent!).UserName;

        public RoundPlayer(GameAppPlayer player) : base(player) 
        {
            Health = 100;
            lastDamage = 0;
        }

        public int Health { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} Health: {1}", UserName, Health);
        }

        public void DecreaseHealth(int damage)
        {
            lastDamage = damage;
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public void UndoDamage() => Health += lastDamage;
    }
}
