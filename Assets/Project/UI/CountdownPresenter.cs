using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;

namespace Project.UI
{
    [UsedImplicitly]
    public sealed class CountdownPresenter: IResettable
    {
        private readonly TMP_Text _text;
        public CountdownPresenter(TMP_Text text)
        {
            _text = text;
            _text.text = string.Empty;
        }

        public async void StartCountDown(int seconds)
        {
            seconds--;
            while (seconds>=0)
            {
                _text.text = seconds.ToString();
                seconds--;
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }

            Reset();
        }

        public void Reset()
        {
            _text.text = string.Empty;
        }
    }
}