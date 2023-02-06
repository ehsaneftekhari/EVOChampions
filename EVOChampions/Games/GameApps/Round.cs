namespace EVOChampions.Games.GameApps
{
    public abstract class Round
    {
        protected Round(RoundPlayer roundPlayer1, RoundPlayer roundPlayer2)
        {
            if (roundPlayer1 == null)
                throw new ArgumentNullException(nameof(roundPlayer1));
            if (roundPlayer2 == null)
                throw new ArgumentNullException(nameof(roundPlayer2));

            player1 = roundPlayer1;
            player2 = roundPlayer2;
        }

        public RoundPlayer player1 { get; private set; }

        public RoundPlayer player2 { get; private set; }

        public RoundPlayer Winner { get; protected set; }

        public void Start()
        {
            while (!IsRoundFinished())
            {
                RoundPlayer Defender = RandomDefender(player1, player2);
                RandomAttackOnDefender(Defender);
                DoRandomDefend(Defender);
            }

            Winner = player1;

            if (IsPlayerDeath(player1))
                Winner = player2;
        }

        public override string ToString()
        {
            string result = "Round:***************************************\n";
            if (Winner == null)
                return "";

            string player1 = this.player1.ToString();
            string player2 = this.player2.ToString();

            if (Winner.UserName == this.player1.UserName)
                player1 += " W";
            else
                player2 += " W";

            result += string.Format("{0} \n{1}\n", player1, player2);

            result += "***************************************/Round";
            return result;
        }

        protected abstract void RandomAttackOnDefender(RoundPlayer Defender);

        protected abstract void DoRandomDefend(RoundPlayer Defender);

        private bool IsPlayerDeath(RoundPlayer player) => player.Health == 0;

        private bool IsRoundFinished() => IsPlayerDeath(player1) || IsPlayerDeath(player2);

        private RoundPlayer RandomDefender(RoundPlayer player1, RoundPlayer player2)
        {
            RoundPlayer Defender = player1;

            Random random = new Random();
            int Chooser = random.Next(0, 2);

            if (Chooser == 0)
                Defender = player2;


            return Defender;
        }
    }
}
