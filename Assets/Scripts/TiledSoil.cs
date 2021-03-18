using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSoil : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    TileState tileState = TileState.normal;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToSoil()
    {
        tileState = TileState.soil;
    }

    public bool IsSoil()
    {
        return tileState == TileState.soil;
    }
}

enum TileState
{
    normal,
    soil
}
