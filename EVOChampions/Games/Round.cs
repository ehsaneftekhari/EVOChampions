namespace EVOChampions.Games
{
    public abstract class Round
    {
        public RoundPlayer RoundPlayer1 { get; private set; }
        public RoundPlayer RoundPlayer2 { get; private set; }

        protected Round(RoundPlayer roundPlayer1, RoundPlayer roundPlayer2)
        {
            if (roundPlayer1 == null)
                throw new ArgumentNullException(nameof(roundPlayer1));
            if (roundPlayer2 == null)
                throw new ArgumentNullException(nameof(roundPlayer2));

            RoundPlayer1 = roundPlayer1;
            RoundPlayer2 = roundPlayer2;
        }

        public abstract void Start();

        public RoundPlayer Winner { get; protected set; }

        public override string ToString()
        {
            string result = "Round:***************************************\n";
            if (Winner == null)
                return "";

            string player1 = RoundPlayer1.ToString();
            string player2 = RoundPlayer2.ToString();

            if (Winner.UserName == RoundPlayer1.UserName)
                player1 += " W";
            else
                player1 += " W";

            result += string.Format("{0} \n{1}\n", player1, player2);

            result += "***************************************/Round";
            return result;
        }
    }
}
