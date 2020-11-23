using System.Collections;
using System.Collections.Generic;
using CardGames;
using TMPro;
using UnityEngine;

public class DeckCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void Display(IList<ICardInstance> deck)
    {
        _text.text = deck.Count.ToString();
    }
}
