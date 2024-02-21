using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    [SerializeField]
    CapsuleCollider2D monPersoSpawn;

    private void Awake()
    {
        monPersoSpawn.transform.position = gameObject.transform.position;
    }
}
