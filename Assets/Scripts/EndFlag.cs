using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    private Controls inputActions;

    private bool playerIsOn;

    private void Awake()
    {
        inputActions = new Controls();
        inputActions.Gameplay.Enable();
    }

    private void Update()
    {
        if (playerIsOn && (Input.GetKeyDown(KeyCode.E) || inputActions.Gameplay.Interact.triggered) && PlayerInventory.Instance.IsInInventory("REDGEM"))
        {
            SceneManager.LoadScene(nextLevel);
            PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerIsOn = true;
        if (PlayerInventory.Instance.IsInInventory("REDGEM"))
        {
            Interaction.instance.ShowText("press E to go to the next level");
        }
        else
        {
            Interaction.instance.ShowText("go get the Red Gem");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsOn = false;
        Interaction.instance.HideText();
    }
}
