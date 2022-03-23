using Project.Model;
using Zenject;

namespace Project.Tests.Play
{
    internal sealed class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RPSModel>().AsSingle().NonLazy();
        }
    }
}
