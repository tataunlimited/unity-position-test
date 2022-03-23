using System;
using JetBrains.Annotations;
using Project.Signals;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    [UsedImplicitly]
    public class PresenterService: IInitializable, IDisposable
    {
        [Inject] public PlayerInputPresenter PlayerInputPresenter;
        [Inject] public PlayerSymbolPresenter PlayerSymbolPresenter;
        [Inject] public OpponentSymbolPresenter OpponentSymbolPresenter;
        [Inject] public CountdownPresenter CountdownPresenter;
        [Inject] public ResultTextPresenter ResultPresenter;

        private readonly SignalBus _signalBus;

        public PresenterService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SymbolsReadySignal>(UpdateSymbols);
            _signalBus.Subscribe<GameOverSignal>(UpdateResult);
            _signalBus.Subscribe<ReadyForCountDownSignal>(InitCountDown);
            _signalBus.Subscribe<ResetGameSignal>(Reset);
        }

        private void UpdateSymbols(SymbolsReadySignal signal)
        {
            PlayerSymbolPresenter.SetSymbol(signal.PlayerHand);
            OpponentSymbolPresenter.SetSymbol(signal.OpponentHand);
        }


        private void UpdateResult(GameOverSignal signal)
        {
            ResultPresenter.ShowResults(signal.Outcome);
        }

        private void InitCountDown(ReadyForCountDownSignal signal)
        {
            CountdownPresenter.StartCountDown(signal.Seconds);   
        }
        private void Reset()
        {
            PlayerInputPresenter.Reset();
            PlayerSymbolPresenter.Reset();
            OpponentSymbolPresenter.Reset();
            CountdownPresenter.Reset();
            ResultPresenter.Reset();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SymbolsReadySignal>(UpdateSymbols);
            _signalBus.Unsubscribe<GameOverSignal>(UpdateResult);
            _signalBus.Unsubscribe<ReadyForCountDownSignal>(InitCountDown);
            _signalBus.Unsubscribe<ResetGameSignal>(Reset);
        }
    }
}
