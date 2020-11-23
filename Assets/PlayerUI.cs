using System;
using CardGames;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HandUI _hand;
    
    [SerializeField] private DeckCounterUI _draw;
    [SerializeField] private DeckCounterUI _discard;
    [SerializeField] private DeckCounterUI _removed;

    private void Start()
    {
        if (_player.Field != null)
        {
            RemoveListeners(_player.Field);
            AddListeners(_player.Field);
            Display(_player.Field);
            Debug.Log("Field Started");
        }
    }

    private void OnEnable()
    {
        if (_player.Field != null)
        {
            AddListeners(_player.Field);
            Display(_player.Field);
            Debug.Log("Field Setup");
        }

        // Display(_player);
    }

    private void OnDisable()
    {
        if (_player.Field != null)
        {
            RemoveListeners(_player.Field);
            Debug.Log("Field Unsetup");
        }
    }

    void AddListeners(PlayerField<ICardInstance> field)
    {
        field.Hand.Changed += HandChanged;
        field.DrawPile.Changed += DeckChanged;
        field.DiscardPile.Changed += DiscardChanged;
        field.RemovePile.Changed += RemovedChanged;
    }
    void RemoveListeners(PlayerField<ICardInstance> field)
    {
        field.Hand.Changed -= HandChanged;
        field.DrawPile.Changed -= DeckChanged;
        field.DiscardPile.Changed -= DiscardChanged;
        field.RemovePile.Changed -= RemovedChanged;
    }
    
    
    

    void Display(PlayerField<ICardInstance> field)
    {
        _hand.Display(field.Hand);
        _draw.Display(field.DrawPile);
        _discard.Display(field.DiscardPile);
        _removed.Display(field.RemovePile);
    }

    void HandChanged(object sender, EventArgs args)
    {
        _hand.Display(_player.Field.Hand);
    }
    void DeckChanged(object sender, EventArgs args)
    {
        _draw.Display(_player.Field.DrawPile);
    }
    void DiscardChanged(object sender, EventArgs args)
    {
        _discard.Display(_player.Field.DiscardPile);
    }
    void RemovedChanged(object sender, EventArgs args)
    {
        _removed.Display(_player.Field.RemovePile);
    }
}
