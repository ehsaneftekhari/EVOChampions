﻿namespace EVOChampions.GameApps.Taken
{
    internal class Taken : GameApp
    {
        public Taken(GamePlayer player1, GamePlayer player2) : base(player1, player2, new TakenCreator(), 4) { }
        public override string Name => "Taken";
    }
}
