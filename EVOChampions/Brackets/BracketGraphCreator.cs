using EVOChampions.Managers;

namespace EVOChampions.Brackets
{
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
