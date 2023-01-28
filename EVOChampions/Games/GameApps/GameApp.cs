namespace EVOChampions.Games.GameApps
{
    public abstract class GameApp
    {
        GameAppCreator creator;
        int winnerRounds;

        public GameApp(GameAppPlayer player1, GameAppPlayer player2, GameAppCreator creator, int winnerRounds)
        {
            if (player1 == null)
                throw new ArgumentNullException(nameof(player1));

            if (player2 == null)
                throw new ArgumentNullException(nameof(player2));

            if (creator == null)
                throw new ArgumentNullException(nameof(creator));

            if (winnerRounds < 1)
                throw new ArgumentOutOfRangeException(nameof(winnerRounds));

            this.winnerRounds = winnerRounds;
            Rounds = new Round[winnerRounds * 2 - 1];
            this.player1 = player1;
            this.player2 = player2;
            this.creator = creator;
        }

        public abstract string Name { get; }

        public GameAppPlayer player1 { get; private set; }

        public GameAppPlayer player2 { get; private set; }

        public GameAppPlayer? Winner { get; protected set; }

        public GameAppPlayer? Loser
        {
            get
            {
                if (Winner == null)
                    return null;

                if (Winner.UserName == player1.UserName)
                    return player2;
                else
                    return player1;
            }
        }

        public int RoundsCount
        {
            get
            {
                for (int i = 0; i < Rounds.Length; i++)
                {
                    if (Rounds[i] == null)
                        return i;
                }
                return 0;
            }
        }

        public Round[] Rounds { get; protected set; }

        public GameAppPlayer Start()
        {
            //for test 
            string user1Username = player1.UserName;
            string user2Username = player2.UserName;

            int player1WinsCount = 0;
            int player2WinsCount = 0;

            for (int i = 0; i < Rounds.Length; i++)
            {
                Rounds[i] = creator.CteateRoundFor(player1, player2);
                Rounds[i].Start();

                if (Rounds[i].Winner.UserName == player1.UserName)
                    player1WinsCount++;
                else
                    player2WinsCount++;

                if (player1WinsCount == winnerRounds)
                {
                    Winner = player1;
                    break;
                }

                if (player2WinsCount == winnerRounds)
                {
                    Winner = player2;
                    break;
                }
            }

            //For test
            if (Winner is null)
                throw new Exception();
            //
            return Winner;
        }

        public override string ToString()
        {
            string result = "Match:+++++++++++++++++++++++++++++++++++++++\n";
            if (Winner == null)
                result += "Match didn`t started";
            else
            {
                result += SummaryToString();
                result += "\n";
                result += RoundsDetailsToString();
            }
            result += "+++++++++++++++++++++++++++++++++++++++/Match";
            return result;
        }

        private string RoundsDetailsToString()
        {
            string result = "";
            if (Rounds == null || Rounds.Length == 0)
                return result;

            result += "Rounds:\n";
            for (int i = 0; i < Rounds.Length; i++)
            {
                if (Rounds[i] == null)
                    break;
                result += string.Format("Round {0}:\n{1}\n", i, Rounds[i].ToString());
            }

            return result;
        }

        private string SummaryToString()
        {
            if (Winner == null)
                return "";

            return string.Format("Winner -> {0} Winned Rounds:{1}\nLoser -> {2} Winned Rounds:{3}",
                             Winner.ToString(),
                             winnerRounds,
                             Loser.ToString(),
                             RoundsCount - winnerRounds);
        }
    }
}
