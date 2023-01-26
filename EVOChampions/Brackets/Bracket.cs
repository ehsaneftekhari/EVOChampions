using EVOChampions.Games;
using EVOChampions.Managers;
using System;
using System.Xml.Linq;

namespace EVOChampions.Brackets
{
    public class Bracket
    {
        internal Node[]? nodes;
        internal Node winnersFinalsNode;
        internal Node losersFinalsNode;

        public Bracket(TournamentPlayer[] tournamentUsers)
        {
            if (tournamentUsers is null)
                throw new ArgumentNullException(nameof(tournamentUsers));

            InitialNodes(tournamentUsers.Length, out nodes!, out winnersFinalsNode, out losersFinalsNode);
            InitialUsers(tournamentUsers, winnersFinalsNode!);
        }

        public int NumberOfLevels => winnersFinalsNode.LevelNumber;
        public int NumberOfRounds => NumberOfLevels - 1;
        public TournamentPlayer? Podium1 => winnersFinalsNode.Winner;
        public TournamentPlayer? Podium2 => winnersFinalsNode.Loser;
        public TournamentPlayer? Podium3 => losersFinalsNode.Winner;

        public Node[] GetNodesOfRound(int rundNumber) => GetNodesOfLevel(rundNumber + 1);

        public Node[] GetNodesOfLevel(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > NumberOfLevels)
                throw new ArgumentOutOfRangeException(nameof(levelNumber));

            Node[] result = new Node[CountNodeOfLevel(levelNumber)];
            int index = 0;
            foreach (Node node in nodes)
            {
                if (node.LevelNumber == levelNumber)
                    result[index++] = node;
            }
            return result;
        }

        public override string ToString()
        {
            string result = "Tournament:=====================================\n";
            for (int i = 1; i <= NumberOfLevels; i++)
            {
                result += string.Format("Round {0} Games:\n{1}\n", i - 1, LevelToString(i));
            }
            result += "=====================================/Bracket";
            return result;
        }

        public string GraphToString()
        {
            BracketGraphCreator bracketPrinter = new BracketGraphCreator(this);
            return bracketPrinter.GetGraph();
        }

        internal int CountNodeOfRound(int rundNumber) => CountNodeOfLevel(rundNumber + 1);

        internal int CountNodeOfLevel(int leveNumber)
        {
            if (leveNumber < 1 || leveNumber > NumberOfLevels)
                throw new ArgumentOutOfRangeException(nameof(leveNumber));

            if (nodes is null)
                return 0;

            int count = 0;
            foreach (Node node in nodes)
            {
                if (node.LevelNumber == leveNumber)
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

        private string LevelToString(int LevelNumber)
        {
            string result = "";
            foreach (Node node in nodes)
            {
                if (node.LevelNumber == LevelNumber)
                {
                    result += string.Format("\n{0}\n", node.ToString());
                }
            }
            return result;
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

    internal class BracketGraphCreator
    {
        Bracket bracket;
        public BracketGraphCreator(Bracket bracket)
        {
            if (bracket is null)
                throw new ArgumentException();

            this.bracket = bracket;
        }

        public string GetGraph()
        {
            string result = "========== Winners Graph ==============\n\n";
            result += GetWinnersGraph();
            result += "\n\n========== Loser Graph ==============\n\n";
            result += GetLoserGraph();

            return result;
        }

        public string GetLoserGraph()
        {
            Node losersFinalsNode = bracket.losersFinalsNode;
            string Player1UserName = losersFinalsNode.Player1!.UserName;
            string Player2UserName = losersFinalsNode.Player2!.UserName;
            string Winner = losersFinalsNode.Winner!.UserName;

            int longestUsename = Player1UserName.Length;
            if (Player2UserName.Length > Player1UserName.Length)
                longestUsename = Player2UserName.Length;

            string result = createString(Player1UserName, longestUsename);
            result += "\n";
            result += createString("  |", longestUsename);
            result += createString(Winner, longestUsename);
            result += "\n";
            result += createString(Player2UserName, longestUsename);
            return result;
        }

        private string GetWinnersGraph()
        {
            string[] whiteboard = new string[bracket.CountNodeOfRound(0) * 2 - 1];
            for (int level = 1; level <= bracket.NumberOfLevels; level++)
            {
                Node[] nodes = bracket.GetNodesOfLevel(level);
                AddNodesToWhiteboard(whiteboard, nodes, level == bracket.NumberOfLevels);
            }
            return CombineArray(whiteboard);
        }

        private string CombineArray(string[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + "\n";
            }
            return result;
        }

        private void AddNodesToWhiteboard(string[] whiteboard, Node[] nodes, bool last = false)
        {
            int level = nodes[0].LevelNumber;
            int passSteps = CalculatePass(level);
            int passedCount = passSteps;
            bool pipeFlag = false;
            int nodesIindex = 0;
            int longestLength = FindLongestUsername(nodes);


            for (int i = CalculatePass(level - 1); i < whiteboard.Length; i++)
            {
                if (passedCount == passSteps)
                {
                    string value = GetNextUserName();
                    AddInWhiteboard(i, value, longestLength);

                    if (last)
                        break;

                    passedCount = 0;
                    pipeFlag = !pipeFlag;
                }
                else
                {
                    if (pipeFlag)
                        AddInWhiteboard(i, "  |", longestLength);
                    else
                        AddInWhiteboard(i, " ", longestLength);

                    passedCount++;
                }

            }

            void AddInWhiteboard(int index, string str, int longestLength)
            {
                if (index < 0 || index >= whiteboard.Length)
                    return;

                if (str == null)
                    whiteboard[index] += createString("<BayPass>", longestLength);
                else
                    whiteboard[index] += createString(str, longestLength);
            }

            int FindLongestUsername(Node[] nodes)
            {
                int length = 0;
                try
                {
                    while (true)
                    {

                        int nextLength = GetNextUserName().Length;
                        if (nextLength > length)
                            length = nextLength;
                    }

                }
                catch
                {
                    nodesIindex = 0;
                    return length;
                }
            }

            string GetNextUserName()
            {
                if (nodesIindex >= nodes.Length)
                    throw new IndexOutOfRangeException();

                TournamentPlayer player = nodes[nodesIindex++].Player;
                if (player == null)
                    return "_";
                else
                    return player.UserName;
            }

            int CalculatePass(int level)
            {
                if (level < 1)
                    return 0;

                if (level == 1)
                    return 1;

                return 2 * CalculatePass(level - 1) + 1;
            }
        }
        string createString(string str, int longestLength)
        {
            for (int i = longestLength - str.Length; i >= 0; i--)
                str += " ";

            str += "   ";
            return str;
        }
    }
}
