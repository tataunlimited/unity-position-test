namespace Project.Model
{
    public class PlayerModel
    {
        private readonly Hand _hand;
        public Hand Hand => _hand;

        public PlayerModel(Hand hand)
        {
            this._hand = hand;
        }
    }
}
