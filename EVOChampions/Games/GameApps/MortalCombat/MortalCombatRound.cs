using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace EVOChampions.Games.GameApps.MortalCombat
{
    internal sealed class MortalCombatRound : Round
    {
        public MortalCombatRound(RoundPlayer player1, RoundPlayer player2) : base(player1, player2) { }

        private void Kick(RoundPlayer Defender) => Defender.DecreaseHealth(10);

        private void Punch(RoundPlayer Defender) => Defender.DecreaseHealth(5);

        private void JumpingKick(RoundPlayer Defender) => Defender.DecreaseHealth(15);

        private void PowerKick(RoundPlayer Defender) => Defender.DecreaseHealth(30);

        private void PowerPunch(RoundPlayer Defender) => Defender.DecreaseHealth(10);

        private void KnifeThrow(RoundPlayer Defender) => Defender.DecreaseHealth(15);

        private void GunFire(RoundPlayer Defender) => Defender.DecreaseHealth(25);

        private void SuperAttack(RoundPlayer Defender) => Defender.DecreaseHealth(40);

        private void Defend(RoundPlayer Defender) => Defender.UndoDamage();

        protected override void RandomAttackOnDefender(RoundPlayer Defender)
        {
            Random random = new Random();
            int Chooser = random.Next(1, 9);

            switch (Chooser)
            {
                case 1:
                    Kick(Defender);
                    break;
                case 2:
                    Punch(Defender);
                    break;
                case 3:
                    JumpingKick(Defender);
                    break;
                case 4:
                    PowerKick(Defender);
                    break;
                case 5:
                    KnifeThrow(Defender);
                    break;
                case 6:
                    PowerPunch(Defender);
                    break;
                case 7:
                    GunFire(Defender);
                    break;
                case 8:
                    SuperAttack(Defender);
                    break;
            }
        }

        protected override void DoRandomDefend(RoundPlayer Defender)
        {
            Random random = new Random();
            int Chooser = random.Next(0, 3);

            //for test
            if (Chooser < 0 || Chooser > 2)
                throw new Exception();

            if (Chooser == 0)
                Defend(Defender);
        }
    }
}
