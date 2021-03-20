using UnityEngine;

[CreateAssetMenu]
public class seedPlantSignal : ItemUseSignal
{
    [SerializeField]
    Plant plant;

    public override void Raise()
    {
        if (listener == null) Debug.LogWarning("No listeners! Add signal to itemUseManager");
        else listener.PlantSeed(plant);
    }
}