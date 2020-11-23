using Core;
using UnityEngine;

namespace CardGames
{
    public interface ICard : IDeepCloneable<ICard>
    {
        string Name { get; }
        string Description { get; }
        int Cost { get; }
        Sprite Graphic { get; }
    }
    
    
}