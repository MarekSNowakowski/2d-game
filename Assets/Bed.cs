using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Sleep sleep = collision.GetComponent<Sleep>();
            sleep.StartSleep(360);
        }
    }
}
