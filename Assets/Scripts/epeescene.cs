using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeescene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeSword();
        }
    }
    
    void TakeSword()
    {
        Destroy(gameObject);
        PlayerMovement.instance.recupEpee = true;
    }
}
