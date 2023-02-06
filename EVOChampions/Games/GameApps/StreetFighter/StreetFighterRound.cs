namespace EVOChampions.Games.GameApps.StreetFighter
{
    internal class StreetFighterRound : Round
    {
        public StreetFighterRound(RoundPlayer character1, RoundPlayer character2) : base(character1, character2) { }

        private void Kick(RoundPlayer Defender) => Defender.DecreaseHealth(10);

        private void Punch(RoundPlayer Defender) => Defender.DecreaseHealth(5);

        private void JumpingKick(RoundPlayer Defender) => Defender.DecreaseHealth(15);

        private void PowerKick(RoundPlayer Defender) => Defender.DecreaseHealth(25);

        private void KnifeThrow(RoundPlayer Defender) => Defender.DecreaseHealth(15);

        private void Defend(RoundPlayer Defender) => Defender.UndoDamage();

        protected override void RandomAttackOnDefender(RoundPlayer Defender)
        {
            Random random = new Random();
            int Chooser = random.Next(1, 6);

            switch (Chooser)
            {
                case 1:
                    Kick(Defender);
                    break;
                case 2:
                    Punch(Defender);
                    break;
                case 3:
                    JumpingKick(Defender);
                    break;
                case 4:
                    PowerKick(Defender);
                    break;
                case 5:
                    KnifeThrow(Defender);
                    break;
            }
        }

        protected override void DoRandomDefend(RoundPlayer Defender)
        {
            Random random = new Random();
            int Chooser = random.Next(0, 3);

            if (Chooser == 0)
                Defend(Defender);
        }
    }
}
