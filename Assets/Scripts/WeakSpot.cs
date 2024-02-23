using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakspot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Destroy(objectToDestroy);
        }
    }
}
//lorsque q'un objet portant le tag "Weapon" rentre dans la collider box l'objet portant la collider est enti�rement d�truis