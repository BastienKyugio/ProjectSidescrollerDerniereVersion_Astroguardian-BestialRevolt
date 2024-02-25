using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lader : MonoBehaviour
{
    private bool isInRange;
    public Text interactUI;
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

   
    void Update()
    {
        if(PlayerMovement.instance.isClimbing && Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            PlayerMovement.instance.isClimbing = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayerMovement.instance.isClimbing = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            PlayerMovement.instance.isClimbing = false;
            interactUI.enabled = false;

        }
    }
}
