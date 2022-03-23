using NUnit.Framework;
using Project.GameCore;
using Project.Model;
using Project.UI;
using Zenject;

namespace Project.Tests.Play
{
    public class InputTest: ZenjectIntegrationTestFixture
    {
        [Inject] private PlayerInputPresenter _playerInputPresenter;
        [Inject] private SymbolPresenter.Symbols _symbols;

        
        [SetUp]
        public void CommonInstall()
        {
            PreInstall();
            GameSettingsInstaller.InstallFromResource("GameSettingsInstaller", Container);
            UIInstaller.Install(Container);
            GameInstaller.Install(Container);
            PostInstall();
            Container.Inject(this);
        }

        [Test]
        public void RockInputTest()
        {
            var playerModel = _playerInputPresenter.GetPlayerModel("rock");
            Assert.That(()=>playerModel!=null && playerModel.Hand == Hand.Rock);
        }
        [Test]
        public void RockSymbolTest()
        {
            var symbolSprite = _symbols.GetSymbol(Hand.Rock);
            Assert.That(()=>symbolSprite!=null && symbolSprite == _symbols.rock);
        }
        
        [Test]
        public void PaperInputTest()
        {
            var playerModel = _playerInputPresenter.GetPlayerModel("paper");
            Assert.That(()=>playerModel!=null && playerModel.Hand == Hand.Paper);
        }
        [Test]
        public void PaperSymbolTest()
        {
            var symbolSprite = _symbols.GetSymbol(Hand.Paper);
            Assert.That(()=>symbolSprite!=null && symbolSprite == _symbols.paper);
        }
        [Test]
        public void ScissorsInputTest()
        {
            var playerModel = _playerInputPresenter.GetPlayerModel("scissors");
            Assert.That(()=>playerModel!=null && playerModel.Hand == Hand.Scissors);
        }
        [Test]
        public void ScissorsSymbolTest()
        {
            var symbolSprite = _symbols.GetSymbol(Hand.Scissors);
            Assert.That(()=>symbolSprite!=null && symbolSprite == _symbols.scissors);
        }
    }
}
