using System;
using System.Collections;
using System.Collections.Generic;
using CardGames;
using UnityEngine;
using UnityEngine.UI;

public class DrawButtonDebug : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _button;

    private PlayerField<ICardInstance> Field => _player.Field;

    private void Awake()
    {
        _button.onClick.AddListener(DrawClick);
    }

    private void DrawClick()
    {
        if (Field.DrawPile.Count > 0)
        {
            var draw = Field.DrawPile.Draw();
            Field.Hand.PushLast(draw);
        }
    }
}
