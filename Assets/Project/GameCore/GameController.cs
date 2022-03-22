using System;
using Cysharp.Threading.Tasks;
using Project.Model;
using Project.Utilities;
using Zenject;

namespace Project.GameCore
{
    public class GameController : IInitializable, IDisposable
    {
        private readonly RpsModel _rpsModel;
        private readonly SignalBus _signalBus;
        private enum GameState{PlayerTurn, Busy}
        private GameState _state;
        
        public GameController(RpsModel rpsModel, SignalBus signalBus)
        {
            _rpsModel = rpsModel;
            _signalBus = signalBus;
            _state = GameState.PlayerTurn;
        }
        
        public void Initialize()
        {
        }
        
        private async void UpdatePlaying(PlayerModel playerModel)
        {

            _state = GameState.Busy;
            _rpsModel.SetPlayerHand(playerModel.Hand);
            var opponentModel = await CreateOpponentModel();
            _rpsModel.SetOpponentHand(opponentModel.Hand);
            
            //Start CountDown
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            //Set Symbols
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            //Display Results
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            Restart();

        }

        private void Restart()
        {
            _state = GameState.PlayerTurn;
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
    }
}
