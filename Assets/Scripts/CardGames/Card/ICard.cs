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


    //    public class TeamTargetter<TTUnit> : ITargetter<TTUnit>
//    {
//        
//    }
}
