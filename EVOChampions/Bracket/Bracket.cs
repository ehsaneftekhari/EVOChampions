using EVOChampions.Games;
using EVOChampions.Managers.AccountManagements;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

namespace EVOChampions.Bracket
{
    public class Bracket
    {
        Block[]? blocks;
        Block? fianl;

        public Bracket(TournamentUser[] tournamentUsers, Creator gameCreator)
        {
            if (tournamentUsers is null)
                throw new ArgumentNullException(nameof(tournamentUsers));

            if (gameCreator is null)
                throw new ArgumentNullException(nameof(gameCreator));

            InitialBlocks(tournamentUsers.Length, out blocks!, out fianl, gameCreator);
            InitialUsers(tournamentUsers, fianl!);
        }

        private void InitialBlocks (int UsersCount, out Block[] blocks, out Block? fianl, Creator gameCreator)
        {
            if (UsersCount == 0)
                throw new ArgumentOutOfRangeException(nameof(UsersCount));

            BracketCreator creator = new BracketCreator(UsersCount, out blocks, gameCreator);
            creator.Create(out fianl);
        }

        private void InitialUsers(TournamentUser[] tournamentUsers, Block fianl)
        {
            if (tournamentUsers is null)
                throw new ArgumentNullException(nameof(tournamentUsers));

            if (fianl is null)
                throw new ArgumentNullException(nameof(fianl));

            for(int i = 0; i < tournamentUsers.Length; i++)
            {
                fianl.Navigate(tournamentUsers[i]);
            }
        }
    }

    internal class BracketCreator
    {
        private Creator gameCreator;
        private Block[] blocks;
        int lastIndex;
        int NumberOFReounds;

        public BracketCreator(int UsersCount, out Block[] blocks, Creator gameCreator)
        {
            var numbers = CalculateNubers(UsersCount);
            NumberOFReounds = numbers.NumberOFReounds;
            blocks = new Block[numbers.NuberOfBlocks];

            this.blocks = blocks;

            lastIndex = -1;

            this.gameCreator = gameCreator;
        }

        public void Create(out Block? block)
        {
            CreateBackward(out block, NumberOFReounds);
        }

        private void CreateBackward(out Block block, int roundNumber)
        {
            block = null;
            if (roundNumber > 0)
            {
                block = new Block(gameCreator);
                blocks[++lastIndex] = block;

                Block? newUpBlock = null;
                CreateBackward(out newUpBlock, roundNumber - 1);

                Block? newDownBlock = null;
                CreateBackward(out newDownBlock, roundNumber - 1);

                if (newUpBlock != null && newDownBlock != null)
                {
                    block.SetUpBlock(newUpBlock);
                    block.SetDownBlock(newDownBlock);
                }
            }
        }

        private int GetNextPowerOf2(int number)
        {
            for (int i = 1; ; i++)
            {
                int powerOf2 = (int)Math.Pow(2, i);
                if (powerOf2 >= number)
                    return powerOf2;
            }
        }

        private (int NumberOFReounds, int NuberOfBlocks) CalculateNubers(int Count)
        {
            (int NumberOFReounds, int NuberOfBlocks) result;

            Count = GetNextPowerOf2(Count);
            result.NuberOfBlocks = Count;
            result.NumberOFReounds = 1;
            while (Count > 1)
            {
                Count /= 2;
                result.NuberOfBlocks += Count;
                result.NumberOFReounds++;
            }
            return result;
        }
    }
}
