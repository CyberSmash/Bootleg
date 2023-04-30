using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;
public class PopulateArea : MonoBehaviour
{
    [Required]
    public TextMeshProUGUI TitleText;

    [Required]
    public TextMeshProUGUI PopulationText;

    [Required]
    public TextMeshProUGUI Distributors;

    private EventSystem _eventSystem = null;


    public void OnClick()
    {
        if (_eventSystem == null)
        {
            _eventSystem = EventSystem.current;
        }
        ButtonProperties buttonProperties = _eventSystem.currentSelectedGameObject.GetComponent<ButtonProperties>();
        TitleText.text = buttonProperties.DisplayName;
        PopulationText.text = $"{buttonProperties.CityStats.Population:n0}";
        Distributors.text = $"{buttonProperties.CityStats.Distributors:n0}";


    }
}
