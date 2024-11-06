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
    [SerializeField] private GameObject leverText;
    [SerializeField] private GameObject bridge;

    private void Start()
    {
        isbroken = true;
        leverText.SetActive(false);
        activated = false;
    }

    private void Update()
    {
        if (playerOnLever)
        {
            if (isbroken)
            {
                if (Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))
                {
                    isbroken = false;
                    GetComponent<SpriteRenderer>().sprite = leftLever;
                    PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && !activated)
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

            leverText.SetActive(true);
            if (isbroken)
            {
                if (PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))
                {
                    leverText.GetComponent<TextMeshProUGUI>().text = "press E to repair lever";
                }
                else
                {
                    leverText.GetComponent<TextMeshProUGUI>().text = "the lever is broken, go get the lever handle";
                }
            }
            else if (!activated)
            {
                leverText.GetComponent<TextMeshProUGUI>().text = "press E to action the lever";
            }
            else
            {
                leverText.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leverText.SetActive(false);
            playerOnLever = false;
        }
    }
}
