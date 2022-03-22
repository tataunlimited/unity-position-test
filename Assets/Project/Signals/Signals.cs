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

    public struct PlayerSymbolReadySignal
    {
        public Hand Hand;
    }
    
    public struct OpponentSymbolReadySignal
    {
        public Hand Hand;
    }

    public struct ResetGameSignal
    {
        
    }

    public struct PlayerSubmitSignal
    {
        public PlayerModel PlayerModel;
    }
}
