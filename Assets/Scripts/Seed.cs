using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    [SerializeField]
    Plant plant;
    [SerializeField]
    CircleCollider2D interactCollider;
    [SerializeField]
    ContactFilter2D contactFilter;

    bool seedSelected = true;

    public void Update()
    {
        if (seedSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] colliders = new Collider2D[1];
                int number = interactCollider.OverlapCollider(contactFilter, colliders);
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
    }
}
