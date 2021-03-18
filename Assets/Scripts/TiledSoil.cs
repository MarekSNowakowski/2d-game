using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSoil : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isSoil = false;
    
    //Plant stuff
    Plant plant;
    int growthTime;
    int currentStage;
    float lastTime;
    float plantTime;
    int maxStage;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!isSoil) this.enabled = false;
    }

    public void ChangeToSoil()
    {
        isSoil = true;
    }

    public bool IsSoil()
    {
        return isSoil;
    }

    public void Plant(Plant plant)
    {
        currentStage = 0;
        this.plant = plant;
        spriteRenderer.sprite = plant.GetSprite(currentStage);
        growthTime = plant.GetGrowthTime(0);
        maxStage = plant.GetMaxStage();
        plantTime = Time.time;
    }

    public void GrowUp()
    {
        currentStage++;
        spriteRenderer.sprite = plant.GetSprite(currentStage);
        growthTime = plant.GetGrowthTime(0);
        plantTime = Time.time;
    }

    public bool isEmptySoil()
    {
        return isSoil && plant==null;
    }

    public void Update()
    {
        if(plant!=null && currentStage < maxStage - 1)
        {
            lastTime = Time.time;
            if (growthTime < lastTime - plantTime)
            {
                GrowUp();
            }
        }
    }
}
