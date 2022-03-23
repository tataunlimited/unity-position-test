using Project.Model;

namespace Project.Signals
{
    public struct ReadyForCountDownSignal
    {
        public int Seconds;
    }
    public struct GameOverSignal
    {
        public Outcome Outcome;
    }

    public struct SymbolsReadySignal
    {
        public Hand PlayerHand;
        public Hand OpponentHand;
    }

    public struct ResetGameSignal
    {
        
    }

    public struct PlayerSubmitSignal
    {
        public PlayerModel PlayerModel;
    }
}
