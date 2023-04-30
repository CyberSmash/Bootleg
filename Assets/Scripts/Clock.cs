using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using TMPro;
public class Clock : MonoBehaviour
{
    // 24 hour time just to keep it sane.

    public TextMeshProUGUI HourGui;
    public FloatVariable GameSpeed;
    public IntReference hour = null;
    private float TimeElapsed;


    private void Awake()
    {
        hour.Value = 12;
    }

    private void Update()
    {
        if (TimeElapsed >= 1.0f)
        {
            hour.Value = (hour.Value + 1) % 24;            
            TimeElapsed = 0;
            HourGui.text = FormatTwelveHourTime(hour.Value);
            return;
        }

        TimeElapsed += Time.deltaTime * GameSpeed.Value;
    }

    private string FormatTwelveHourTime(int hour)
    {
        string ampm = IsAmPm(hour);
        long twelveHour = hour % 12;
        if (twelveHour == 0)
            twelveHour = 12;

        return string.Format("{0}:00 {1}", (twelveHour).ToString("00"), ampm);
    }

    private string IsAmPm(float hour)
    {
        return hour >= 12 ? "PM" : "AM";
    }
}
