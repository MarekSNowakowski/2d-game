using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plant : ScriptableObject
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    int maxStage;
    [SerializeField]
    List<int> growthTime = new List<int>();

    List<Sprite> spriteList = new List<Sprite>();

    public Sprite GetSprite(int currentStage)
    {
        return sprites[currentStage];
    }

    public int GetGrowthTime(int index)
    {
        return growthTime[index];
    }

    public int GetMaxStage()
    {
        return maxStage;
    }
}
