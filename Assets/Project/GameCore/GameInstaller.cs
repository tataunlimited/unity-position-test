using Project.Model;
using Project.Signals;
using Project.UI;
using Zenject;

namespace Project.GameCore
{
    internal sealed class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RpsModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            InstallSignals();
            BindSignals();
        }

        

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerSubmitSignal>();
            Container.DeclareSignal<ReadyForCountDownSignal>();
            Container.DeclareSignal<PlayerSymbolReadySignal>();
            Container.DeclareSignal<OpponentSymbolReadySignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.DeclareSignal<ResetGameSignal>();
        }
        
        private void BindSignals()
        {
            Container.BindSignal<PlayerSubmitSignal>()
                .ToMethod<GameController>((gc, signal) => gc.ValidateState(signal.PlayerModel)).FromResolve();
            Container.BindSignal<ReadyForCountDownSignal>()
                .ToMethod<CountdownPresenter>((cp, signal) => cp.StartCountDown(signal.Seconds)).FromResolve();
            Container.BindSignal<PlayerSymbolReadySignal>()
                .ToMethod<PlayerSymbolPresenter>((ps, signal) => { ps.SetSymbol(signal.Hand); }).FromResolve();
            Container.BindSignal<OpponentSymbolReadySignal>()
                .ToMethod<OpponentSymbolPresenter>((os, signal) => { os.SetSymbol(signal.Hand); }).FromResolve();
            Container.BindSignal<GameOverSignal>()
                .ToMethod<ResultTextPresenter>((rt, signal) => { rt.ShowResults(signal.Outcome); }).FromResolve();
            Container.BindSignal<ResetGameSignal>().ToMethod<IResettable>(x => x.Reset).FromResolveAll();

        }
    }
}
