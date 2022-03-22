using NUnit.Framework;
using Project.Model;
using Zenject;

namespace Project.Tests.Play
{
    internal sealed class  RpmRuleTest : ZenjectIntegrationTestFixture
    {
        [Inject] private RpsModel _rpsModel;
        
        [SetUp]
        public void CommonInstall()
        {
            PreInstall();
            GameInstaller.Install(Container);
            PostInstall();
            Container.Inject(this);
        }
        
        [Test]
        public void RockBeatsScissors()
        {
            _rpsModel.SetPlayerHand(Hand.Rock);
            _rpsModel.SetOpponentHand(Hand.Scissors);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Win);

        }
        
        [Test]
        public void ScissorsLosesToRock()
        {
            _rpsModel.SetPlayerHand(Hand.Scissors);
            _rpsModel.SetOpponentHand(Hand.Rock);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Lose);
        }
        
        [Test]
        public void ScissorsBeatsPaper()
        {
            _rpsModel.SetPlayerHand(Hand.Scissors);
            _rpsModel.SetOpponentHand(Hand.Paper);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Win);
        }
        
        [Test]
        public void PaperLosesToScissors()
        {
            _rpsModel.SetPlayerHand(Hand.Paper);
            _rpsModel.SetOpponentHand(Hand.Scissors);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Lose);
        }
        
        [Test]
        public void PaperBeatsRock()
        {
            _rpsModel.SetPlayerHand(Hand.Paper);
            _rpsModel.SetOpponentHand(Hand.Rock);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Win);
        }
        
        [Test]
        public void RockLosesToPaper()
        {
            _rpsModel.SetPlayerHand(Hand.Rock);
            _rpsModel.SetOpponentHand(Hand.Paper);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Lose);
        }
        
        [Test]
        public void EqualResultsInTie()
        {
            _rpsModel.SetPlayerHand(Hand.Rock);
            _rpsModel.SetOpponentHand(Hand.Rock);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Tie);
            _rpsModel.SetPlayerHand(Hand.Paper);
            _rpsModel.SetOpponentHand(Hand.Paper);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Tie);
            _rpsModel.SetPlayerHand(Hand.Scissors);
            _rpsModel.SetOpponentHand(Hand.Scissors);
            Assert.That(_rpsModel.DetermineWinner() == Outcome.Tie);
        }
    }
}
