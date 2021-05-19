using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    internal sealed class GameViewInstaller : MonoInstaller<GameViewInstaller>
    {
        [SerializeField] private TMP_InputField playerInput;
        
        [SerializeField] private Image playerSymbol;
        [SerializeField] private Image opponentSymbol;
        
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private TMP_Text resultText;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerInputController>().AsSingle().WithArguments(playerInput).NonLazy();
            
            Container.Bind<PlayerSymbolController>().AsSingle().WithArguments(playerSymbol).NonLazy();
            Container.Bind<OpponentSymbolController>().AsSingle().WithArguments(opponentSymbol).NonLazy();
            
            Container.Bind<CountdownController>().AsSingle().WithArguments(countdownText).NonLazy();
            Container.Bind<ResultTextController>().AsSingle().WithArguments(resultText).NonLazy();
        }
    }
}