namespace EVOChampions.Games
{
    public abstract class Game
    {
        GameCreator creator;
        int winnerRounds;

        public Game(GamePlayer player1, GamePlayer player2, GameCreator creator, int winnerRounds)
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

        public abstract string Name{ get;}

        public GamePlayer player1 { get; private set; }

        public GamePlayer player2 { get; private set; }

        public GamePlayer? Winner { get; protected set; }

        public GamePlayer? Loser
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

        public Round[] Rounds { get; protected set; }

        public GamePlayer Start()
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
    }
}
