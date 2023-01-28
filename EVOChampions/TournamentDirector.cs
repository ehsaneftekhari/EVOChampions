using EVOChampions.Brackets;
using EVOChampions.Games.GameApps;

namespace EVOChampions
{
    internal class GameDirector
    {
        Bracket bracket;
        GameAppCreator gameCreator;
        public GameDirector(Bracket bracket, GameAppCreator gameCreator)
        {
            if (bracket is null)
                throw new ArgumentNullException(nameof(bracket));

            if (gameCreator is null)
                throw new ArgumentNullException(nameof(gameCreator));

            this.bracket = bracket;
            this.gameCreator = gameCreator;
        }


        public void start()
        {
            int numberOfRounds = bracket.NumberOfRounds;
            for (int i = 1; i <= numberOfRounds; i++)
            {
                Node[] nodes = bracket.GetNodesOfRound(i);
                CreateGames(nodes);
                StrartGames(nodes);
            }
        }

        private void CreateGames(Node[] nodes)
        {
            if (nodes == null) throw new ArgumentNullException(nameof(nodes));

            for (int j = 0; j < nodes.Length; j++)
            {
                Node node = nodes[j];

                if (node.Player1 is not null && node.Player2 is not null)
                {
                    GameApp game = gameCreator.CteateGameFor(node.Player1!, node.Player2!);
                    nodes[j].Game = game;
                }
            }

        }

        private void StrartGames(Node[] nodes)
        {
            if (nodes == null) throw new ArgumentNullException(nameof(nodes));

            for (int j = 0; j < nodes.Length; j++)
            {
                Node node = nodes[j];

                if (node is null)
                    throw new Exception();

                if (node.Player1 is not null && node.Player2 is not null)
                    nodes[j].Game!.Start();
                else
                    ByPassPlayer(nodes[j]);
            }
        }

        private void ByPassPlayer(Node node)
        {
            switch (node.Player1 is null, node.Player2 is null)
            {
                case (true, false):
                    node.Player = node.Player2;
                    break;
                case (false, true):
                    node.Player = node.Player1;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
