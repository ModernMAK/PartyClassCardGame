using System;
using System.Collections;
using System.Collections.Generic;
using CardGames;
using UnityEditor.Build;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private DeckSO _deckSo;
    
    private Deck<ICardReference> _deck;
    private PlayerField<ICardInstance> _playerField;

    public Deck<ICardReference> Deck => _deck;
    public PlayerField<ICardInstance> Field => _playerField;

    private void Awake()
    {
        _deck = _deckSo.CreateInstance();
        _playerField = new PlayerField<ICardInstance>();
        _playerField.Reset(_deck);
        
    }

}
