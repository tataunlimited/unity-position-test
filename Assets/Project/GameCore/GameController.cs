using System;
using Cysharp.Threading.Tasks;
using Project.Model;
using Project.Signals;
using Project.Utilities;
using Zenject;

namespace Project.GameCore
{
    public class GameController : IInitializable, IDisposable
    {
        private readonly RpsModel _rpsModel;
        private readonly SignalBus _signalBus;
        private readonly Settings _settings;
        private readonly ReadyForCountDownSignal _readyForCountDownSignal;
        private readonly ResetGameSignal _resetGameSignal;
        private enum GameState{PlayerTurn, Busy}
        private GameState _state;
        
        public GameController(RpsModel rpsModel,Settings settings, SignalBus signalBus)
        {
            _rpsModel = rpsModel;
            _settings = settings;
            _signalBus = signalBus;
            _readyForCountDownSignal = new ReadyForCountDownSignal {Seconds = _settings.waitForSymbolUpdate};
            _resetGameSignal = new ResetGameSignal();
        }
        public void Initialize()
        {
            _state = GameState.PlayerTurn;
            
        }
        public void ValidateState(PlayerModel playerModel)
        {
            if(_state!= GameState.PlayerTurn || playerModel == null)
                return;
            UpdatePlaying(playerModel);
        }
        
        
        private async void UpdatePlaying(PlayerModel playerModel)
        {

            _state = GameState.Busy;
            _rpsModel.SetPlayerHand(playerModel.Hand);
            var opponentModel = await CreateOpponentModel();
            _rpsModel.SetOpponentHand(opponentModel.Hand);
            _signalBus.Fire(_readyForCountDownSignal);
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.waitForSymbolUpdate));
            _signalBus.Fire(new SymbolsReadySignal{PlayerHand = playerModel.Hand, OpponentHand = opponentModel.Hand});
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.waitForGameOver));
            var outCome = _rpsModel.DetermineWinner();
            _signalBus.Fire(new GameOverSignal{Outcome = outCome});
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.waitForRestart));
            Restart();

        }

        private void Restart()
        {
            _state = GameState.PlayerTurn;
            _signalBus.Fire(_resetGameSignal);
        }
        private static async UniTask<PlayerModel> CreateOpponentModel()
        {
            int aiChoice = await RandomGenerator.GetRandomChoice();
            if (aiChoice < 0 || aiChoice > 2)
            {
                throw new SystemException();
            }
            return new PlayerModel((Hand)aiChoice);
        }
        
    


        public void Dispose()
        {
            
        }

        [Serializable]
        public class Settings
        {
            public int waitForSymbolUpdate;
            public float waitForGameOver;
            public float waitForRestart;
        }

        
    }
}
