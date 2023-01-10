using EVOChampions.Games;
using EVOChampions.Managers.AccountManagements;
using System.Threading.Tasks.Dataflow;

namespace EVOChampions.Bracket
{
    internal class Block
    {
        private TournamentUser? startPlayer;
        private Game? game;
        private Creator GameCreator;
        private int navigatedCount;

        public Block(Creator GameCreator)
        {
            if (GameCreator is null)
                throw new ArgumentNullException(nameof(GameCreator));
        }

        public Block(Creator GameCreator, Block upBlock, Block downBlock) : this(GameCreator)
        {
            try
            {
                SetUpBlock(upBlock);
                SetDownBlock(downBlock);
            }
            catch { throw; }
        }


        public int RoundNumber
        {
            get
            {
                if (UpBlock is null)
                    return 1;
                else
                    return UpBlock.RoundNumber + 1;
            }
        }

        public Game? Game
        {
            get => game;
            private set
            {
                if (value != null)
                {
                    startPlayer = null;
                    game = value;
                }
            }
        }

        public Block? UpBlock { get; private set; }

        public Block? DownBlock { get; private set; }

        public Block? NextBlock { get; private set; }

        public TournamentUser? Player
        {
            get
            {
                if (Game == null)
                    return startPlayer;
                else
                {
                    Player? tempWinner = Game.Winner;
                    if (tempWinner != null && tempWinner.Parent != null)
                        return (TournamentUser)tempWinner.Parent!;
                    else
                        return null;
                }
            }
            set
            {
                if (value != null)
                {
                    game = null;
                    startPlayer = value;
                    CkearBlocks();
                }
            }
        }


        public Game? CreateGame()
        {
            if (UpBlock is null || DownBlock is null)
                return null;

            return GameCreator.CteateGame(UpBlock!.Player!, DownBlock!.Player!);
        }

        public void Navigate(TournamentUser tournamentUser)
        {
            if (RoundNumber == 1)
            {
                MakeStarterBlock(tournamentUser);
            }
            else
            {
                NavigateBack(tournamentUser);
            }

            navigatedCount++;
        }

        private void NavigateBack(TournamentUser tournamentUser)
        {
            int upNavigated = UpBlock.navigatedCount;
            int downNavigated = DownBlock.navigatedCount;
            switch ((upNavigated > downNavigated, upNavigated == downNavigated))
            {
                case (true, false):
                    NavigateDownBlock(tournamentUser);
                    break;
                case (false, true):
                    RandomNavigateBack(tournamentUser);
                    break;
                case (false, false):
                    NavigateUpBlock(tournamentUser);
                    break;
            }
        }

        private void RandomNavigateBack(TournamentUser tournamentUser)
        {
            Random random = new Random();
            int randNumber = random.Next(1, 3);
            if (randNumber == 1)
                NavigateDownBlock(tournamentUser);
            else
                NavigateUpBlock(tournamentUser);
        }

        private void NavigateDownBlock(TournamentUser tournamentUser)
        {
            if (DownBlock is null)
                throw new Exception();

            DownBlock.Navigate(tournamentUser);
        }

        private void NavigateUpBlock(TournamentUser tournamentUser)
        {
            if (UpBlock is null)
                throw new Exception();

            UpBlock.Navigate(tournamentUser);
        }

        private void MakeStarterBlock(TournamentUser tournamentUser)
        {
            if (startPlayer is null && UpBlock is null && DownBlock is null)
            {
                Player = tournamentUser;
                navigatedCount = 1;
            }
            else
            {
                throw new Exception();
            }
        }

        public void SetUpBlock(Block upBlock)
        {
            if (upBlock is null)
                throw new ArgumentNullException($"Argument {nameof(upBlock)} can not be null");

            UpBlock = upBlock;
            upBlock.NextBlock = this;
        }

        public void SetDownBlock(Block downBlock)
        {
            if (downBlock is null)
                throw new ArgumentNullException($"Argument {nameof(downBlock)} can not be null");

            DownBlock = downBlock;
            downBlock.NextBlock = this;
        }

        private void CkearBlocks()
        {
            UpBlock = null;
            DownBlock = null;
        }
    }
}
