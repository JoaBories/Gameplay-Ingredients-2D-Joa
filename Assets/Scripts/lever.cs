using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lever : MonoBehaviour
{
    private bool isbroken;
    private bool activated;
    private bool playerOnLever;
    [SerializeField] private Sprite leftLever;
    [SerializeField] private Sprite rightLever;
    [SerializeField] private GameObject bridge;

    private Controls inputActions;

    private void Awake()
    {
        inputActions = new Controls();
        inputActions.Gameplay.Enable();
    }

    private void Start()
    {
        isbroken = true;
        activated = false;
    }

    private void Update()
    {
        if (playerOnLever)
        {
            if (isbroken)
            {
                if ((Input.GetKeyDown(KeyCode.E) || inputActions.Gameplay.Interact.triggered) && PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))
                {
                    isbroken = false;
                    GetComponent<SpriteRenderer>().sprite = leftLever;
                    PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
                }
            }
            else
            {
                if ((Input.GetKeyDown(KeyCode.E) || inputActions.Gameplay.Interact.triggered) && !activated)
                {
                    GetComponent<SpriteRenderer>().sprite = rightLever;
                    bridge.GetComponent<Animator>().Play("Bridge down");
                    activated = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnLever = true;

            if (isbroken)
            {
                if (PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))
                {
                    Interaction.instance.ShowText("repair lever");
                }
                else
                {
                    Interaction.instance.ShowText("the lever is broken, go get the lever handle");
                }
            }
            else if (!activated)
            {
                Interaction.instance.ShowText("action the lever");
            }
            else
            {
                Interaction.instance.ShowText("");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interaction.instance.HideText();
            playerOnLever = false;
        }
    }
}
