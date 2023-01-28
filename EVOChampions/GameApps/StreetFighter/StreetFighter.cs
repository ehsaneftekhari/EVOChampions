﻿namespace EVOChampions.GameApps.StreetFighter
{
    internal class StreetFighter : GameApp
    {
        public StreetFighter(GamePlayer player1, GamePlayer player2) : base(player1, player2, new StreetFighterCreator(), 4) { }

        public override string Name => "StreetFighter";
    }
}