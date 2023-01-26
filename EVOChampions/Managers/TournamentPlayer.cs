namespace EVOChampions.Managers
{
    public sealed class TournamentPlayer : Account
    {
        public string UserName => ((User)Parent!).UserName;

        public TournamentPlayer(User user) : base(CheckNull(user)) { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
