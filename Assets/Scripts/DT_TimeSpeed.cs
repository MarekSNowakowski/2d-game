using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT_TimeSpeed : MonoBehaviour
{
    [SerializeField]
    DayNightController dayNightController;
    bool playing = true;
    [SerializeField]
    TMPro.TextMeshProUGUI playStopButton;

    public void StopPlay()
    {
        if(playing)
        {
            dayNightController.ChangeSpeed(0);
            playing = false;
            playStopButton.text = ">";
        }
        else
        {
            dayNightController.ChangeSpeed(1);
            playing = true;
            playStopButton.text = "II";
        }
    }

    public void SpeedUp(int multiplier)
    {
        dayNightController.ChangeSpeed(multiplier);
        if(!playing)
        {
            playStopButton.text = "II";
            playing = true;
        }
    }

    public void SkipTime(int timeToSkip)
    {
        dayNightController.SkipTime(timeToSkip);
    }
}
