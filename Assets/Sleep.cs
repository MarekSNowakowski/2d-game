using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    DayCycle dayCycle;
    [SerializeField]
    Slider sleepSlider;
    int sleepLevel;
    int maxSleepLevel = 480;

    public void StartSleep(int time)
    {
        if(sleepLevel < maxSleepLevel/3)
        {
            StartCoroutine(FadeInAndOut(time));
            sleepLevel += time;
            if (sleepLevel > maxSleepLevel) sleepLevel = maxSleepLevel;
            sleepSlider.value = sleepLevel;
        }
    }

    private void Start()
    {
        sleepLevel = 360;
        sleepSlider.maxValue = maxSleepLevel;
        sleepSlider.value = sleepLevel;
    }

    public void LowerSleepLevel()
    {
        sleepLevel--;
        if (sleepLevel <= 0) StartSleep(240);
        sleepSlider.value = sleepLevel;
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
        
    }
}
