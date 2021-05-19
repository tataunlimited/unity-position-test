using JetBrains.Annotations;
using UnityEngine.UI;

namespace Project.UI
{
    public abstract class SymbolController
    {
        protected SymbolController(Image image)
        {
        }
    }

    [UsedImplicitly]
    public sealed class PlayerSymbolController : SymbolController
    {
        public PlayerSymbolController(Image image) : base(image)
        {
        }
    }

    [UsedImplicitly]
    public sealed class OpponentSymbolController : SymbolController
    {
        public OpponentSymbolController(Image image) : base(image)
        {
        }
    }
}