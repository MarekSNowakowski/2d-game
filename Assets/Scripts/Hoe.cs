using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    public bool hoeSelected = true;
    [SerializeField]
    CircleCollider2D interactCollider;
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
                int number = interactCollider.OverlapCollider(contactFilter, colliders);
                if(number > 0)
                {
                    colliders[0].GetComponent<TiledSoil>().ChangeToSoil();
                    StartCoroutine(HoeAnimCoroutine());
                }
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
