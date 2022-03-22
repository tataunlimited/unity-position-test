using System;
using JetBrains.Annotations;
using Project.Model;
using TMPro;

namespace Project.UI
{
    [UsedImplicitly]
    public sealed class ResultTextPresenter: IResettable
    {
        private readonly TMP_Text _text;
        public ResultTextPresenter(TMP_Text text)
        {
            _text = text;
        }

        public void ShowResults(Outcome outcome)
        {
            _text.text = outcome switch
            {
                Outcome.Win => "Player Win!",
                Outcome.Lose => "AI Win!",
                Outcome.Tie => "Tie!",
                Outcome.WrongInput => "Invalid Input!",
                _ => throw new ArgumentOutOfRangeException(nameof(outcome), outcome, null)
            };
        }

        public void Reset()
        {
            _text.text = string.Empty;
        }
    }
}