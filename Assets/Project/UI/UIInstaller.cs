using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    internal sealed class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField] private TMP_InputField playerInput;
        
        [SerializeField] private Image playerSymbol;
        [SerializeField] private Image opponentSymbol;
        
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private TMP_Text resultText;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerInputPresenter>().AsSingle().WithArguments(playerInput).NonLazy();
            
            Container.Bind<PlayerSymbolPresenter>().AsSingle().WithArguments(playerSymbol).NonLazy();
            Container.Bind<OpponentSymbolPresenter>().AsSingle().WithArguments(opponentSymbol).NonLazy();
            
            Container.Bind<CountdownPresenter>().AsSingle().WithArguments(countdownText).NonLazy();
            Container.Bind<ResultTextPresenter>().AsSingle().WithArguments(resultText).NonLazy();
        }
    }
}