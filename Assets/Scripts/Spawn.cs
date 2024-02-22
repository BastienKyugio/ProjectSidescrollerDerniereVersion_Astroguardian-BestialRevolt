using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    CapsuleCollider2D monPersoSpawn;
    public static Spawn instance;
        private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Spawn dans la scène");
            return;
        }

        instance = this;


    
        monPersoSpawn.transform.position = gameObject.transform.position;
    }
}
