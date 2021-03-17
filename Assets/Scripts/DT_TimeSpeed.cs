using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT_TimeSpeed : MonoBehaviour
{
    [SerializeField]
    DayCycle dayCycle;
    bool playing = true;
    [SerializeField]
    TMPro.TextMeshProUGUI playStopButton;

    public void StopPlay()
    {
        if(playing)
        {
            dayCycle.ChangeSpeed(0);
            playing = false;
            playStopButton.text = ">";
        }
        else
        {
            dayCycle.ChangeSpeed(1);
            playing = true;
            playStopButton.text = "II";
        }
    }

    public void SpeedUp(int multiplier)
    {
        dayCycle.ChangeSpeed(multiplier);
        if(!playing)
        {
            playStopButton.text = "II";
            playing = true;
        }
    }

    public void SkipTime(int timeToSkip)
    {
        dayCycle.SkipTime(timeToSkip);
    }
}
