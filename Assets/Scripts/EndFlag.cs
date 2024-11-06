using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject interactionText;

    private bool playerIsOn;

    private void Update()
    {
        if (playerIsOn && Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("REDGEM"))
        {
            SceneManager.LoadScene(nextLevel);
            PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerIsOn = true;
        interactionText.SetActive(true);
        if (PlayerInventory.Instance.IsInInventory("REDGEM"))
        {
            interactionText.GetComponent<TextMeshProUGUI>().text = "press E to go to the next level";
        }
        else
        {
            interactionText.GetComponent<TextMeshProUGUI>().text = "go get the Red Gem";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsOn = false;
        interactionText.SetActive(false);
    }
}
