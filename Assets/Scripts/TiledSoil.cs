using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TiledSoil : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isSoil = false;
    
    //Plant stuff
    Plant plant;
    int growthTime;
    int currentStage;
    float time;
    float plantTime;
    int maxStage;
    float wateredTime = 30f;
    bool watered = false;

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

    public void Water(Tilemap wateredSoilTileMap, Vector3Int currentCell)
    {
        StartCoroutine(wateredCO(wateredSoilTileMap, currentCell));
    }

    IEnumerator wateredCO(Tilemap wateredSoilTileMap, Vector3Int currentCell)
    {
        watered = true;
        yield return new WaitForSeconds(wateredTime);
        watered = false;
        wateredSoilTileMap.SetTile(currentCell, null);
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
        if(plant!=null && watered && currentStage < maxStage - 1)
        {
            time += Time.deltaTime;
            if (growthTime < time)
            {
                GrowUp();
                time = 0;
            }
        }
    }
}
