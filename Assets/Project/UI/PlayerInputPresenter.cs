using System;
using JetBrains.Annotations;
using Project.Model;
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
        public PlayerInputPresenter(TMP_InputField field)
        {
            _field = field;
        }
        public void Initialize()
        {
            var inputStream = Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.Return));
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