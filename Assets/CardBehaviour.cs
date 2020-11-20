using System;
using System.Collections;
using System.Collections.Generic;
using CardGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    
    [Header("Target")]
    public Card _cardSO;

    private ICard _card;
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _graphicImage;
    

    public TMP_Text NameUI => _nameText;
    public TMP_Text DescriptionUI => _descriptionText;
    public TMP_Text CostUI => _costText;
    public Image GraphicUI => _graphicImage;


    private void Start()
    {    
        if(_card == null)
        {            
            if (_cardSO != null)
            {
                _card = _cardSO;
            }
        }
        if(_card != null)
            UpdateDisplay(_card);
        
    }

    private void UpdateDisplay(ICard card)
    {
        if(card == null)
            throw new NotImplementedException();
            
        NameUI.text = card.Name;
        DescriptionUI.text = card.Description;
        CostUI.text = card.Cost.ToString();
        GraphicUI.sprite = card.Graphic;
    }
}
