using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    Light light;
    int hour;
    int minutes;
    float beginingTime;
    float time;
    float lastTime;
    [SerializeField]
    float dayLengthInMinutes=15;
    [SerializeField]
    int beginingHour=7;
    [SerializeField]
    int endHour=24;
    [Header("Light")]
    [SerializeField]
    float morningLight = 0.5f;
    [SerializeField]
    float nightLight = 0;
    [SerializeField]
    float dayLight = 0.75f;
    [SerializeField]
    float sunDownHour = 22;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        hour = beginingHour;
        minutes = 0;
        beginingTime = Time.time;
        time = beginingTime;
        light.intensity = morningLight;
    }


    // Update is called once per frame
    void Update()
    {
        float time = Time.time - lastTime;
        if (time - beginingTime > dayLengthInMinutes/(endHour-beginingHour))
        {
            minutes++;
            lastTime = Time.time;
            Debug.Log(hour + " : " + minutes);
        }
        if(minutes==60)
        {
            hour++;
            minutes = 0;
        }
        if (hour == 24)
        {
            hour = 0;
        }
        //Light stuff

        //Getting brighter      
        if (hour > 4 && hour < 12) light.intensity = morningLight + (dayLight - morningLight) * (hour / 12f);
        //Getting darker
        if (hour > 12 && hour < sunDownHour) light.intensity = nightLight + dayLight * (sunDownHour - hour)/(sunDownHour-12);
    }
}
