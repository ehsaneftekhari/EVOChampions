﻿using EVOChampions.Games;
using EVOChampions.Managers;
using System.Threading.Tasks.Dataflow;

namespace EVOChampions.Brackets
{
    public class Node
    {
        private TournamentPlayer? starterPlayer;
        private Game? game;
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

        public Game? Game
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

        public Node? NextNode { get; private set; }

        public TournamentPlayer? Winner
        {
            get => Player;
        }

        public TournamentPlayer? Loser
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

        public TournamentPlayer? Player
        {
            get
            {
                if (Game == null)
                    return starterPlayer;
                else
                {
                    GamePlayer? tempWinner = Game.Winner;
                    if (tempWinner != null && tempWinner.Parent != null)
                        return (TournamentPlayer)tempWinner.Parent!;
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

        public TournamentPlayer? Player1
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

        public TournamentPlayer? Player2
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

        public void Navigate(TournamentPlayer tournamentUser)
        {
            if (LevelNumber == 1)
            {
                MakeStarterBlock(tournamentUser);
            }
            else
            {
                NavigateBack(tournamentUser);
            }

            navigatedCount++;
        }

        private void NavigateBack(TournamentPlayer tournamentUser)
        {
            int upNavigated = UpNode.navigatedCount;
            int downNavigated = DownNode.navigatedCount;
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

        private void RandomNavigateBack(TournamentPlayer tournamentUser)
        {
            Random random = new Random();
            int randNumber = random.Next(1, 3);
            if (randNumber == 1)
                NavigateDownBlock(tournamentUser);
            else
                NavigateUpBlock(tournamentUser);
        }

        private void NavigateDownBlock(TournamentPlayer tournamentUser)
        {
            if (DownNode is null)
                throw new Exception();

            DownNode.Navigate(tournamentUser);
        }

        private void NavigateUpBlock(TournamentPlayer tournamentUser)
        {
            if (UpNode is null)
                throw new Exception();

            UpNode.Navigate(tournamentUser);
        }

        private void MakeStarterBlock(TournamentPlayer tournamentUser)
        {
            if (starterPlayer is null && UpNode is null && DownNode is null)
            {
                Player = tournamentUser;
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
            upBlock.NextNode = this;
        }

        public void SetDownBlock(Node downBlock)
        {
            if (downBlock is null)
                throw new ArgumentNullException($"Argument {nameof(downBlock)} can not be null");

            DownNode = downBlock;
            downBlock.NextNode = this;
        }
    }
}
