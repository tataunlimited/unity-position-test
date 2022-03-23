using Project.Model;
using Project.Signals;
using Zenject;

namespace Project.Tests.Play
{
    internal sealed class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RPSModel>().AsSingle().NonLazy();
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerSubmitSignal>();
        }
    }
}
