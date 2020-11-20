using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _graphicImage;
    
    public TMP_Text NameUI => _nameText;
    public TMP_Text DescriptionUI => _nameText;
    public TMP_Text CostUI => _nameText;
    public Image GraphicUI => _graphicImage;


}
