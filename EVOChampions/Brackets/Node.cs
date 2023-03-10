using EVOChampions.Games;
using EVOChampions.Games.GameApps;

namespace EVOChampions.Brackets
{
    public class Node
    {
        private GamePlayer? starterPlayer;
        private GameApp? game;
        bool UpNodeGivsLoser;
        bool DownNodeGivsLoser;
        private int navigatedCount;

        public Node(bool upBlockGivsLoser = false, bool downBlockGivsLoser = false)
        {
            this.DownNodeGivsLoser = downBlockGivsLoser;
            this.UpNodeGivsLoser = upBlockGivsLoser;
        }

        public Node(Node upNode, Node downNode, bool upBlockGivsLoser = false, bool downBlockGivsLoser = false) : this(upBlockGivsLoser, downBlockGivsLoser)
        {
            try
            {
                SetUpBlock(upNode);
                SetDownBlock(downNode);
            }
            catch { throw; }
        }

        public int LevelNumber
        {
            get
            {
                if (UpNode is null)
                    return 1;
                else
                    return UpNode.LevelNumber + 1;
            }
        }

        public GameApp? Game
        {
            get => game;
            set
            {
                if (value != null)
                {
                    starterPlayer = null;
                    game = value;
                }
            }
        }

        public Node? UpNode { get; private set; }

        public Node? DownNode { get; private set; }

        public Node? WinnersNextNode { get; private set; }
        public Node? LoserNextNode { get; private set; }

        public GamePlayer? Winner
        {
            get => Player;
        }

        public GamePlayer? Loser
        {
            get
            {
                if (Player is null)
                    return null;
                if (Player1 != null && Player.UserName == Player1.UserName)
                    return Player2;
                else
                    return Player1;
            }
        }

        public GamePlayer? Player
        {
            get
            {
                if (Game == null)
                    return starterPlayer;
                else
                {
                    GameAppPlayer? tempWinner = Game.Winner;
                    if (tempWinner != null && tempWinner.Parent != null)
                        return (GamePlayer)tempWinner.Parent!;
                    else
                        return null;
                }
            }
            set
            {
                if (value != null)
                {
                    game = null;
                    starterPlayer = value;
                }
            }
        }

        public GamePlayer? Player1
        {
            get
            {
                if (UpNode is null)
                    return null;
                if (UpNodeGivsLoser)
                    return UpNode.Loser;
                else
                    return UpNode.Winner;
            }
        }

        public GamePlayer? Player2
        {
            get
            {
                if (DownNode is null)
                    return null;
                if (DownNodeGivsLoser)
                    return DownNode.Loser;
                else
                    return DownNode.Winner;
            }
        }

        public void Navigate(GamePlayer gameUser)
        {
            if (LevelNumber == 1)
            {
                MakeStarterBlock(gameUser);
            }
            else
            {
                NavigateBack(gameUser);
            }

            navigatedCount++;
        }

        public override string ToString()
        {
            string result = "Node:----------------------------------------";

            if (Player1 != null || Player2 != null)
            {
                result += string.Format("\nPlayer1: {0}", GetPlayerInString(Player1));
                result += string.Format("\nPlayer2: {0}", GetPlayerInString(Player2));

                result += string.Format("\n{0} Winns\n", Player);
            }
            else
                result += string.Format("\n{0}\n", Player);

            if (Game is not null)
            {
                result += "Ditails:\n";
                result += Game.ToString();
                result += "\n";
            }
            result += "----------------------------------------/Node";
            return result;

            string GetPlayerInString(GamePlayer? Player1)
            {
                if (Player1 is null)
                    return "_";
                return Player1.ToString();
            }
        }


        private void NavigateBack(GamePlayer gameUser)
        {
            int upNavigated = UpNode.navigatedCount;
            int downNavigated = DownNode.navigatedCount;
            switch ((upNavigated > downNavigated, upNavigated == downNavigated))
            {
                case (true, false):
                    NavigateDownBlock(gameUser);
                    break;
                case (false, true):
                    RandomNavigateBack(gameUser);
                    break;
                case (false, false):
                    NavigateUpBlock(gameUser);
                    break;
            }
        }

        private void RandomNavigateBack(GamePlayer gameUser)
        {
            Random random = new Random();
            int randNumber = random.Next(1, 3);
            if (randNumber == 1)
                NavigateDownBlock(gameUser);
            else
                NavigateUpBlock(gameUser);
        }

        private void NavigateDownBlock(GamePlayer gameUser)
        {
            if (DownNode is null)
                throw new Exception();

            DownNode.Navigate(gameUser);
        }

        private void NavigateUpBlock(GamePlayer gameUser)
        {
            if (UpNode is null)
                throw new Exception();

            UpNode.Navigate(gameUser);
        }

        private void MakeStarterBlock(GamePlayer gameUser)
        {
            if (starterPlayer is null && UpNode is null && DownNode is null)
            {
                Player = gameUser;
                navigatedCount = 1;
            }
            else
            {
                throw new Exception();
            }
        }

        public void SetUpBlock(Node upBlock)
        {
            if (upBlock is null)
                throw new ArgumentNullException($"Argument {nameof(upBlock)} can not be null");

            UpNode = upBlock;

            if (UpNodeGivsLoser)
                upBlock.LoserNextNode = this;
            else
                upBlock.WinnersNextNode = this;
        }

        public void SetDownBlock(Node downBlock)
        {
            if (downBlock is null)
                throw new ArgumentNullException($"Argument {nameof(downBlock)} can not be null");

            DownNode = downBlock;
            if (DownNodeGivsLoser)
                downBlock.LoserNextNode = this;
            else
                downBlock.WinnersNextNode = this;
        }
    }
}
