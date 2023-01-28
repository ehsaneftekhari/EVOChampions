using EVOChampions.Managers;

namespace EVOChampions.Games
{
    public sealed class GamePlayer : ParentChildrenKeeper
    {
        public string UserName => ((User)Parent!).UserName;

        public GamePlayer(User user) : base(CheckNull(user)) { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
