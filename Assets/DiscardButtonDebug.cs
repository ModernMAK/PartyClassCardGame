using System.Collections;
using System.Collections.Generic;
using CardGames;
using UnityEngine;
using UnityEngine.UI;

public class DiscardButtonDebug : MonoBehaviour
{
    [SerializeField]
    private Player _player;
[SerializeField]
    private Button _button;
    
    private PlayerField<ICardInstance> Field => _player.Field;

    private void Awake()
    {
        _button.onClick.AddListener(DiscardClick);
    }

    private void DiscardClick()
    {
        while (Field.Hand.Count > 0)
        {
            Field.DiscardPile.Add(Field.Hand.PopLast());
        }
    }
}
