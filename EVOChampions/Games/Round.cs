namespace EVOChampions.Games
{
    public abstract class Round
    {
        public RoundPlayer Character1 { get; private set; }
        public RoundPlayer Character2 { get; private set; }

        protected Round(RoundPlayer character1, RoundPlayer character2)
        {
            if (character1 == null)
                throw new ArgumentNullException(nameof(character1));
            if (character2 == null)
                throw new ArgumentNullException(nameof(character2));

            Character1 = character1;
            Character2 = character2;
        }

        public abstract void Start();

        public RoundPlayer Winner { get; protected set; }
    }
}
