using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    DayNightController dayCycle;
    [SerializeField]
    Slider sleepSlider;
    [SerializeField]
    float maxTimeWithNoSleep;
    float lastSleepTime;

    public void StartSleep(int time)
    {
        if(Time.time - lastSleepTime > maxTimeWithNoSleep *2/3)
        {
            StartCoroutine(FadeInAndOut(time));
            lastSleepTime = Time.time;
            sleepSlider.value = lastSleepTime - Time.time;
        }
    }

    private void Start()
    {
        lastSleepTime = Time.time - 0.1f * maxTimeWithNoSleep; ;
        sleepSlider.maxValue = maxTimeWithNoSleep;
        sleepSlider.value = Time.time - lastSleepTime;
    }

    IEnumerator FadeInAndOut(int time)
    {
        //fade out
        playerMovement.ImpareMovement(true);
        dayCycle.SkipTime(time);
        yield return new WaitForSeconds(2);
        playerMovement.ImpareMovement(false);
        //fade in
    }

    public void Update()
    {
        sleepSlider.value = Time.time - lastSleepTime;
        if (Time.time - lastSleepTime > maxTimeWithNoSleep)
        {
            StartSleep(4);
        }
    }
}
