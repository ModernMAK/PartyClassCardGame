using System;
using System.Collections;
using System.Collections.Generic;
using CardGames;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("Target")]
    public CardSO cardSo;

    private ICardInstance _card;
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
            if (cardSo != null)
            {
                _card = cardSo.CreateInstance();
            }
        }
        if(_card != null)
            UpdateDisplay(_card);
        
    }

    public void SetCard(ICardInstance card)
    {
        _card = card;
        UpdateDisplay(_card);
    }

    private void UpdateDisplay(ICardInstance card)
    {
        if(card == null)
            throw new NotImplementedException();
            
        NameUI.text = card.Name;
        DescriptionUI.text = card.Description;
        CostUI.text = card.Cost.ToString();
        GraphicUI.sprite = card.Graphic;
    }
}
