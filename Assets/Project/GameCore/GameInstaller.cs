using Project.Model;
using UnityEngine;
using Zenject;

namespace Project.GameCore
{
    internal sealed class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RpsModel>().AsSingle().NonLazy();
        }
    }
}
