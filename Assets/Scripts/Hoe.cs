using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    public bool hoeSelected = true;
    [SerializeField]
    CircleCollider2D[] interactCollider;
    [SerializeField]
    ContactFilter2D contactFilter;
    Animator animator;
    PlayerMovement playerMovement;
    bool hoeing;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (hoeSelected && !hoeing)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("interact"))
            {
                Collider2D[] colliders = new Collider2D[1];
                int number = interactCollider[4].OverlapCollider(contactFilter, colliders);
                if(number > 0)
                {
                    TiledSoil soil = colliders[0].GetComponent<TiledSoil>();
                    soil.ChangeToSoil();
                    RoundTiles(soil);
                    StartCoroutine(HoeAnimCoroutine());
                }
            }
        }
    }

    void RoundTiles(TiledSoil soil4)
    {
        //Check the array
        Collider2D[] colliders = new Collider2D[1];
        TiledSoil[] soilArray = new TiledSoil[9];
        bool[] soilArrayMap = new bool[9];
        for (int i = 0; i < 9; i++)
        {
            if (i == 4)
            {
                soilArray[4] = soil4;
                soilArrayMap[4] = true;
            }
            else if (interactCollider[i].OverlapCollider(contactFilter, colliders) > 0)
            {
                if(colliders[0].GetComponent<TiledSoil>().IsSoil())
                {
                    soilArray[i] = colliders[0].GetComponent<TiledSoil>();
                    soilArrayMap[i] = true;
                }
                else
                {
                    soilArrayMap[i] = false;
                }
            }
            else
            {
                soilArray[i] = null;
                soilArrayMap[i] = false;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if(soilArrayMap[i])
            {
                soilArray[i].Round();
            }
        }
    }

    IEnumerator HoeAnimCoroutine()
    {
        hoeing = true;
        animator.SetBool("Hoeing", true);
        playerMovement.ImpareMovement(true);
        yield return new WaitForSeconds(0.3f);
        playerMovement.ImpareMovement(false);
        animator.SetBool("Hoeing", false);
        hoeing = false;
    }
}
