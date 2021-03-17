using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSoil : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    TileState tileState = TileState.normal;
    TiledSoil[] adjacentSoil;
    [SerializeField]
    CircleCollider2D[] adjacentSoilColliders;
    [SerializeField]
    ContactFilter2D contactFilter;
    [SerializeField]
    Sprite[] SpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToSoil()
    {
        tileState = TileState.soil;
        spriteRenderer.enabled = true;
    }

    public bool IsSoil()
    {
        return tileState == TileState.soil;
    }

    public bool[] GetSoilMap()
    {
        Collider2D[] colliders = new Collider2D[1];
        bool[] soilMap = new bool[9];
        for (int i = 0; i < 8; i++)
        {
            if (i < 4)
            {
                if (adjacentSoilColliders[i].OverlapCollider(contactFilter, colliders) > 0)
                {
                    if (colliders[0].GetComponent<TiledSoil>().IsSoil())
                    {
                        soilMap[i] = true;
                    }
                    else
                    {
                        soilMap[i] = false;
                    }
                }
                else
                {
                    soilMap[i] = false;
                }
            }
            else if (i == 4)
            {
                soilMap[4] = true;
            }
            else
            {
                if (adjacentSoilColliders[i].OverlapCollider(contactFilter, colliders) > 0)
                {
                    if (colliders[0].GetComponent<TiledSoil>().IsSoil())
                    {
                        soilMap[i+1] = true;
                    }
                    else
                    {
                        soilMap[i+1] = false;
                    }
                }
                else
                {
                    soilMap[i+1] = false;
                }
            }
        }
        return soilMap;
    }

    public void Round()
    {
        bool[] soilMap = GetSoilMap();

        if (soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
         && soilMap[3] == false && soilMap[4] == true && soilMap[5] == false
         && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[13]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[10]; }
        else if(soilMap[0] == false && soilMap[1] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[0]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[1]; }
        else if(soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == true && soilMap[7] == true) { spriteRenderer.sprite = SpriteArray[2]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == true && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[3]; }
        else if(soilMap[1] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[7] == false) { spriteRenderer.sprite = SpriteArray[4]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == false && soilMap[7] == true && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[5]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[6]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[7]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[8]; }
        else if(soilMap[0] == false && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[9]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[11]; }
        else if(soilMap[1] == true
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == false
             && soilMap[7] == true) { spriteRenderer.sprite = SpriteArray[12]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == false
             && soilMap[7] == true) { spriteRenderer.sprite = SpriteArray[14]; }
        else if (soilMap[1] == true
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[14]; spriteRenderer.flipY = true; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[15]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[16]; }
        else if(soilMap[0] == false && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[17]; }
        else if(soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == false) { spriteRenderer.sprite = SpriteArray[18]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[19]; }
        else if(soilMap[0] == true && soilMap[1] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[20]; }
        else if(soilMap[0] == false && soilMap[1] == true && soilMap[2] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[21]; }
        else if(soilMap[0] == false && soilMap[1] == false
             && soilMap[3] == false && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == false && soilMap[7] == false) { spriteRenderer.sprite = SpriteArray[22]; }
        else if (soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[22]; spriteRenderer.flipX = true; }
        else if(soilMap[0] == false && soilMap[1] == true && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == false
             && soilMap[6] == false && soilMap[7] == false && soilMap[8] == false) { spriteRenderer.sprite = SpriteArray[23]; }
        else if(soilMap[0] == true && soilMap[1] == true && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[24]; }
        else if(soilMap[0] == false && soilMap[1] == false && soilMap[2] == false
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[25]; }
        else if(soilMap[0] == false && soilMap[1] == true && soilMap[2] == true
             && soilMap[3] == true && soilMap[4] == true && soilMap[5] == true
             && soilMap[6] == true && soilMap[7] == true && soilMap[8] == true) { spriteRenderer.sprite = SpriteArray[26]; }
        else Debug.Log(soilMap[0] + " " + soilMap[1] + " " + soilMap[2] + " " + soilMap[3] + " " + soilMap[4] + " " + soilMap[5] + " " + soilMap[6] + " " + soilMap[7] + " " + soilMap[8]);
        Debug.Log(spriteRenderer.sprite);
    }
}

enum TileState
{
    normal,
    soil
}
