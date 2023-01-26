﻿using EVOChampions.Managers;

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
            for (int i = 2; i <= NumberOfLevels; i++)
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
}
