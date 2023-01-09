﻿using EVOChampions.Error;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game
{
    public abstract class Game
    {
        RoundCreator roundCreator;
        MessageGenerator messageGenerator;
        int winnerRounds;
        public Game(Player player1, Player player2, RoundCreator roundCreator, int winnerRounds)
        {
            messageGenerator = new MessageGenerator();

            if (player1 == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("player1", nameof(player1)));

            if (player2 == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("player2", nameof(player2)));

            if (roundCreator == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("roundCreator", nameof(roundCreator)));

            if(winnerRounds < 1)
                throw new ArgumentOutOfRangeException(messageGenerator.ArgumentOutOfRange("roundCreator"));

            this.winnerRounds = winnerRounds;
            Rounds = new Round[winnerRounds * 2 - 1];
            this.player1 = player1;
            this.player2 = player2;
            this.roundCreator = roundCreator;
        }

        public Player player1 { get; private set; }

        public Player player2 { get; private set; }

        public Player? Winner { get; protected set; }

        public Round[] Rounds { get; protected set; }

        protected Player Start()
        {
            int player1WinsCount = 0;
            int player2WinsCount = 0;

            for (int i = 0; i < Rounds.Length; i++)
            {
                Rounds[i] = roundCreator.Cteate(player1, player2);
                Rounds[i].Start();

                if (Rounds[i].Winner.Id == player1.Id)
                    player1WinsCount++;
                else
                    player2WinsCount++;

                if(player1WinsCount == winnerRounds)
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
            return Winner;
        }
    }
}
