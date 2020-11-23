using Core;
using UnityEngine;

namespace CardGames
{
    public interface ICard
    {
        string Name { get; }
        string Description { get; }
        int Cost { get; }
        Sprite Graphic { get; }
    }
    public interface ICardReference : IInstancable<ICardInstance>, ICard
    {
    }

    public interface ICardInstance : IReferencable<ICardReference>, ICard
    {
        new int Cost { get; set; }
    }


}