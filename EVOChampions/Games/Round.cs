namespace EVOChampions.Games
{
    public abstract class Round
    {
        public Character Character1 { get; private set; }
        public Character Character2 { get; private set; }

        protected Round(Character character1, Character character2)
        {
            if (character1 == null)
                throw new ArgumentNullException(nameof(character1));
            if (character2 == null)
                throw new ArgumentNullException(nameof(character2));

            Character1 = character1;
            Character2 = character2;
        }

        public abstract void Start();

        public Character Winner { get; protected set; }
    }
}
