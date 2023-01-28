﻿namespace EVOChampions.Games.GameApps.StreetFighter
{
    internal class StreetFighterRound : Round
    {
        public StreetFighterRound(RoundPlayer character1, RoundPlayer character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = RoundPlayer1;
        }
    }
}