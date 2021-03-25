using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class ItemUseManager : MonoBehaviour
{
    [SerializeField]
    List<ItemUseSignal> signals;

    [SerializeField]
    CircleCollider2D interactCollider;
    Animator animator;
    PlayerMovement playerMovement;
    bool busy;

    [Header("hoe")]
    [SerializeField]
    ContactFilter2D soilContactFilter;
    [SerializeField]
    Tilemap soilTileMap;
    [SerializeField]
    TileBase soilTile;
    [SerializeField]
    Tilemap wateredSoilTileMap;
    [SerializeField]
    TileBase wateredTile;

    public void OnsignalRaised(string itemCode)
    {
        if (itemCode == "hoe")
        {
            Hoe();
        }
        else if (itemCode == "waterCan")
        {
            WateringCan();
        }
        else
        {
            Debug.LogWarning("Item use code is incorrect: " + itemCode);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        foreach (ItemUseSignal itemUseSignal in signals)
            itemUseSignal.RegisterListener(this);
    }

    /*
    private void OnDisable()
    {
        foreach (ItemUseSignal itemUseSignal in signals)
            itemUseSignal.DeRegisterListeners(this);
    }
    */

    //Hoe
    void Hoe()
    {
        if (!busy)
        {
            Collider2D[] colliders = new Collider2D[1];
            int number = interactCollider.OverlapCollider(soilContactFilter, colliders);
            if (number > 0)
            {
                TiledSoil soil = colliders[0].GetComponent<TiledSoil>();
                soil.enabled = true;
                if (!soil.IsSoil())
                {
                    soil.ChangeToSoil();
                    Vector3Int currentCell = soilTileMap.WorldToCell(interactCollider.transform.position);
                    soilTileMap.SetTile(currentCell, soilTile);
                    StartCoroutine(HoeAnimCoroutine());
                }
            }
        }
    }

    void WateringCan()
    {
        if (!busy)
        {
            Collider2D[] colliders = new Collider2D[1];
            int number = interactCollider.OverlapCollider(soilContactFilter, colliders);
            if (number > 0)
            {
                TiledSoil soil = colliders[0].GetComponent<TiledSoil>();
                soil.enabled = true;
                if(soil.IsSoil())
                {
                    Vector3Int currentCell = wateredSoilTileMap.WorldToCell(interactCollider.transform.position);
                    soil.Water(wateredSoilTileMap, currentCell);
                    wateredSoilTileMap.SetTile(currentCell, wateredTile);
                    StartCoroutine(WateringAnimCoroutine());
                }
            }
        }
    }

    IEnumerator HoeAnimCoroutine()
    {
        busy = true;
        animator.SetBool("Hoeing", true);
        playerMovement.ImpareMovement(true);
        yield return new WaitForSeconds(0.3f);
        playerMovement.ImpareMovement(false);
        animator.SetBool("Hoeing", false);
        busy = false;
    }

    IEnumerator WateringAnimCoroutine()
    {
        busy = true;
        animator.SetBool("Watering", true);
        playerMovement.ImpareMovement(true);
        yield return new WaitForSeconds(0.3f);
        playerMovement.ImpareMovement(false);
        animator.SetBool("Watering", false);
        busy = false;
    }

    //Seed
    public void PlantSeed(Plant plant)
    {
        Collider2D[] colliders = new Collider2D[1];
        int number = interactCollider.OverlapCollider(soilContactFilter, colliders);
        if (number > 0)
        {
            TiledSoil soil = colliders[0].GetComponent<TiledSoil>();
            if (soil.isEmptySoil())
            {
                soil.Plant(plant);
            }
        }
    }
}