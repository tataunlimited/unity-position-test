using Project.UI;
using UnityEngine;
using Zenject;

namespace Project.GameCore
{
    [CreateAssetMenu(menuName = "Game Settings/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {

        public GameSettings gameSettings;

        [System.Serializable]
        public class GameSettings
        {
            public GameController.Settings settings;
            public SymbolPresenter.Symbols symbols;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings.settings);
            Container.BindInstance(gameSettings.symbols);
        }
    }
}
