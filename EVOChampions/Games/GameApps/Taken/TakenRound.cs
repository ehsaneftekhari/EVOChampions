namespace EVOChampions.Games.GameApps.Taken
{
    internal class TakenRound : Round
    {
        public TakenRound(RoundPlayer character1, RoundPlayer character2) : base(character1, character2) { }

        private void Kick(RoundPlayer Defender) => Defender.DecreaseHealth(5);

        private void Punch(RoundPlayer Defender) => Defender.DecreaseHealth(2);

        private void JumpingKick(RoundPlayer Defender) => Defender.DecreaseHealth(7);

        private void PowerKick(RoundPlayer Defender) => Defender.DecreaseHealth(10);

        private void BackKick(RoundPlayer Defender) => Defender.DecreaseHealth(6);

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
                    BackKick(Defender);
                    break;
            }
        }

        protected override void DoRandomDefend(RoundPlayer Defender)
        {
            Random random = new Random();
            int Chooser = random.Next(0, 5);

            if (Chooser == 0)
                Defend(Defender);
        }
    }
}
