using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using TMPro;
public class UpdateMoney : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    public void Awake()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        if (moneyText == null)
        {
            Debug.LogError("Error: Could not find money UI component.");
        }
    }

    public void OnMoneyUpdated(float Money)
    {
        moneyText.text = string.Format("Money: ${0:0.00}", Money);
    }
    
}
