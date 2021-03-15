using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    Light light;
    [Header("Time")]
    int time;
    [SerializeField]
    TMPro.TextMeshProUGUI timerText;
    int beginingTime = 420;
    float beginingTimeSeconds;
    float seconds;
    float lastTimeSeconds;
    int maxTime = 1440;
    [SerializeField]
    float dayLengthInMinutes=15;
    [Header("Light")]
    [SerializeField]
    float dayLight = 0.85f;
    [SerializeField]
    int sunUpTime = 5*60;
    [SerializeField]
    int sunDownTime = 22*60;
    bool changingLight;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        time = beginingTime;
        beginingTimeSeconds = Time.time;
        seconds = beginingTimeSeconds;
        light.intensity = 0.7f;
    }


    // Update is called once per frame
    void Update()
    {
        seconds = Time.time - lastTimeSeconds;
        if (seconds - beginingTimeSeconds > dayLengthInMinutes/24)
        {
            time++;
            timerText.text = (time / 60).ToString("D2") + " : " + (time % 60).ToString("D2");
            lastTimeSeconds = Time.time;
        }
        if(time==1440)
        {
            time = 0;
        }
        //Light stuff
        if (time == 200) ChangeLight(0.35f, 120);
        if (time == sunUpTime - 120) ChangeLight(0.7f, 120);
        if (time == 11*60) ChangeLight(dayLight, 60);
        if (time == 15*60) ChangeLight(0.7f, 120);
        if (time == 18*60) ChangeLight(0.4f, 120);
        if (time == sunDownTime - 120) ChangeLight(0, 120);
    }

    void ChangeLight(float lightChange, float changeTime)
    {
        if(!changingLight)
        {
            float startLight = light.intensity;
            float changeTimeInSeconds = changeTime * dayLengthInMinutes / 24;
            StartCoroutine(ChangeLightCO(startLight, lightChange, changeTimeInSeconds));
        }
    }

    IEnumerator ChangeLightCO(float startLight, float lightChange, float changeTimeInSeconds)
    {
        changingLight = true;
        for(int i = 0; i <= 100; i++)
        {
            light.intensity += (lightChange - startLight) / 100f;       
            yield return new WaitForSeconds(changeTimeInSeconds / 100f);
        }
        light.intensity = lightChange;
        changingLight = false;
    }
}
