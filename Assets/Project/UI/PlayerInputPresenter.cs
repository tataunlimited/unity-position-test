using System;
using JetBrains.Annotations;
using Project.Model;
using Project.Signals;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    [UsedImplicitly]
    public sealed class PlayerInputPresenter: IInitializable, IResettable
    {
        private readonly TMP_InputField _field;
        private readonly SignalBus _signalBus;
        public PlayerInputPresenter(TMP_InputField field, SignalBus signalBus)
        {
            _field = field;
            _signalBus = signalBus;
        }
        public void Initialize()
        {
            Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.Return))
                .Subscribe(xs => ValidateInput());
            Reset();
        }

        private void ValidateInput()
        {
            var playerModel = GetPlayerModel(_field.text);
            if(playerModel!=null)
                _signalBus.Fire(new PlayerSubmitSignal{PlayerModel = playerModel});
        }
        public PlayerModel GetPlayerModel(string text)
        {
            var value = text.ToUpper();
            if (value != "ROCK" && value != "PAPER" && value != "SCISSORS")
            {
                return null;
            }

            return value switch
            {
                "ROCK" => new PlayerModel(Hand.Rock),
                "PAPER" => new PlayerModel(Hand.Paper),
                "SCISSORS" => new PlayerModel(Hand.Scissors),
                _ => null
            };
        }


        public void Reset()
        {
            _field.text = String.Empty;
        }
    }
}