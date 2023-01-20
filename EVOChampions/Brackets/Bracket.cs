using EVOChampions.Games;
using EVOChampions.Managers.AccountManagements;
using System.Xml.Linq;

namespace EVOChampions.Brackets
{
    public class Bracket
    {
        Node[]? nodes;
        Node winnersFinalsNode;
        Node losersFinalsNode;

        public Bracket(TournamentPlayer[] tournamentUsers)
        {
            if (tournamentUsers is null)
                throw new ArgumentNullException(nameof(tournamentUsers));

            InitialNodes(tournamentUsers.Length, out nodes!, out winnersFinalsNode, out losersFinalsNode);
            InitialUsers(tournamentUsers, winnersFinalsNode!);
        }

        public int NumberOfRounds => winnersFinalsNode.LevelNumber - 1;
        public TournamentPlayer? Podium1 => winnersFinalsNode.Winner;
        public TournamentPlayer? Podium2 => winnersFinalsNode.Loser;
        public TournamentPlayer? Podium3 => losersFinalsNode.Winner;

        public Node[] GetNodesOf(int rundNumber)
        {
            if(rundNumber < 0 || rundNumber > NumberOfRounds)
                throw new ArgumentOutOfRangeException(nameof(rundNumber));

            Node[] result = new Node[CountNodeOfRound(rundNumber)];
            int index = 0;
            foreach(Node node in nodes)
            {
                if(node.LevelNumber - 1 == rundNumber)
                    result[index++] = node;
            }
            return result;
        }

        private int CountNodeOfRound(int rundNumber)
        {
            if (rundNumber < 0 || rundNumber > NumberOfRounds)
                throw new ArgumentOutOfRangeException(nameof(rundNumber));

            if (nodes is null)
                return 0;

            int count = 0;
            foreach(Node node in nodes)
            {
                if(node.LevelNumber - 1 == rundNumber)
                    count++;
            }
            return count;
        }

        private void InitialNodes(int UsersCount, out Node[] nodes, out Node? fianlNode, out Node? losersFinalsNode)
        {
            if (UsersCount == 0)
                throw new ArgumentOutOfRangeException(nameof(UsersCount));

            BracketCreator creator = new BracketCreator(UsersCount);
            creator.Create(out nodes, out fianlNode, out losersFinalsNode);
        }

        private void InitialUsers(TournamentPlayer[] tournamentUsers, Node fianl)
        {
            if (tournamentUsers is null)
                throw new ArgumentNullException(nameof(tournamentUsers));

            if (fianl is null)
                throw new ArgumentNullException(nameof(fianl));

            for (int i = 0; i < tournamentUsers.Length; i++)
            {
                fianl.Navigate(tournamentUsers[i]);
            }
        }
    }

    internal class BracketCreator
    {
        private Node[] Nodes;
        int lastIndex;
        int NumberOFReounds;

        public BracketCreator(int UsersCount)
        {
            var numbers = CalculateNumbers(UsersCount);
            NumberOFReounds = numbers.NumberOFReounds;
            Nodes = new Node[numbers.NuberOfBlocks + 1];
            lastIndex = -1;
        }

        public void Create(out Node[] Nodes, out Node winnersFinalsNode, out Node? losersFinalsNode)
        {
            CreateBackward(out winnersFinalsNode, NumberOFReounds);
            Nodes = this.Nodes;
            losersFinalsNode = new Node(winnersFinalsNode.UpNode!, winnersFinalsNode.DownNode!, true, true);
            AddToNodes(losersFinalsNode);
        }

        private void CreateBackward(out Node node, int roundNumber)
        {
            node = null;
            if (roundNumber > 0)
            {
                node = new Node();
                AddToNodes(node);

                Node? newUpBlock = null;
                CreateBackward(out newUpBlock, roundNumber - 1);

                Node? newDownBlock = null;
                CreateBackward(out newDownBlock, roundNumber - 1);

                if (newUpBlock != null && newDownBlock != null)
                {
                    node.SetUpBlock(newUpBlock);
                    node.SetDownBlock(newDownBlock);
                }
            }
        }

        private void AddToNodes(Node node)
        {
            Nodes[++lastIndex] = node;
        }

        private (int NumberOFReounds, int NuberOfBlocks) CalculateNumbers(int Count)
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

        private int GetNextPowerOf2(int number)
        {
            for (int i = 1; ; i++)
            {
                int powerOf2 = (int)Math.Pow(2, i);
                if (powerOf2 >= number)
                    return powerOf2;
            }
        }
    }
}
