using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    Light light;
    [Header("Time")]
    int time;
    int beginingTime = 630;//420;
    float beginingTimeSeconds;
    float seconds;
    float lastTimeSeconds;
    int maxTime = 1440;
    [SerializeField]
    float dayLengthInMinutes=15;
    [Header("Light")]
    [SerializeField]
    float dayLight = 0.75f;
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
        light.intensity = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        seconds = Time.time - lastTimeSeconds;
        if (seconds - beginingTimeSeconds > dayLengthInMinutes/24)
        {
            time++;
            lastTimeSeconds = Time.time;
        }
        if(time==1440)
        {
            time = 0;
        }
        //Light stuff
        if (time == 200) ChangeLight(0.25f, 60);
        if (time == sunUpTime - 120) ChangeLight(0.6f, 120);
        if (time == 11*60) ChangeLight(dayLight, 60);
        if (time == 16*60) ChangeLight(0.55f, 60);
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
