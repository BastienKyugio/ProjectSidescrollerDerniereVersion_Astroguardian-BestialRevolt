using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    [SerializeField]
    CapsuleCollider2D monPersoSpawn;
    public static PlayerSpawn instance;
        private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerSpawn dans la scène");
            return;
        }

        instance = this;


    
        monPersoSpawn.transform.position = gameObject.transform.position;
    }
}
