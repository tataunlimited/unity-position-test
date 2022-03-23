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
            Container.DeclareSignal<SymbolsReadySignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.DeclareSignal<ResetGameSignal>();
        }
        
        private void BindSignals()
        {
            Container.BindSignal<PlayerSubmitSignal>()
                .ToMethod<GameController>((gc, signal) => gc.ValidateState(signal.PlayerModel)).FromResolve();
        }
    }
}
