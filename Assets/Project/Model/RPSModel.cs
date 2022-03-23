using JetBrains.Annotations;

namespace Project.Model
{
    [UsedImplicitly]
    public class RPSModel
    {
        private Hand _playerHand;
        private Hand _opponentHand;

        public void SetPlayerHand(Hand value)
        {
            _playerHand = value;
        }

        public void SetOpponentHand(Hand value)
        {
            _opponentHand = value;
        }

        public Outcome DetermineWinner()
        {
            switch (_playerHand)
            {
                case Hand.Paper when _opponentHand == Hand.Rock:
                case Hand.Rock when _opponentHand  == Hand.Scissors:
                case Hand.Scissors when _opponentHand  == Hand.Paper:
                    return Outcome.Win;
                
                case Hand.Paper when _opponentHand == Hand.Scissors:
                case Hand.Scissors when _opponentHand == Hand.Rock:
                case Hand.Rock when _opponentHand == Hand.Paper:
                    return Outcome.Lose;
                
                default:
                    return Outcome.Tie;
            }
        }
    }
    public enum Hand {Rock, Paper, Scissors }
    public enum Outcome { Win, Lose, Tie, WrongInput}
}

