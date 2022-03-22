using System;
using JetBrains.Annotations;
using Project.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public abstract class SymbolPresenter
    {
        private readonly Image _image;
        private readonly Symbols _symbols;
        
        protected SymbolPresenter(Image image, Symbols symbols)
        {
            _image = image;
            _symbols = symbols;
        }

        public void SetSymbol(Hand hand)
        {
            _image.sprite = _symbols.GetSymbol(hand);
        }

        public void Reset()
        {
            _image.sprite = _symbols.questionMark;
        }
        
        [Serializable]
        public class Symbols
        {
            public Sprite rock;
            public Sprite paper;
            public Sprite scissors;
            public Sprite questionMark;

            public Sprite GetSymbol(Hand hand)
            {
                return hand switch
                {
                    Hand.Rock => rock,
                    Hand.Paper => paper,
                    Hand.Scissors => scissors,
                    _ => throw new ArgumentOutOfRangeException(nameof(hand), hand, null)
                };
            }
        }
    }

    [UsedImplicitly]
    public sealed class PlayerSymbolPresenter : SymbolPresenter
    {
        public PlayerSymbolPresenter(Image image) : base(image)
        {
        }
    }

    [UsedImplicitly]
    public sealed class OpponentSymbolPresenter : SymbolPresenter
    {
        public OpponentSymbolPresenter(Image image) : base(image)
        {
        }
    }
}