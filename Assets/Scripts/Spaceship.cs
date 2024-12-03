using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    private Controls inputActions;

    private bool playerOnSpaceship;

    private GameObject player;
    [SerializeField] private GameObject canva;

    private void Awake()
    {
        inputActions = new Controls();
        inputActions.Enable();
    }

    private void Update()
    {
        if (inputActions.Gameplay.Interact.triggered && playerOnSpaceship)
        {
            player.SetActive(false);
            canva.SetActive(false);
            GetComponent<Animator>().Play("shipend");
            Interaction.instance.HideText();
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interaction.instance.ShowText("End the Game");
            playerOnSpaceship = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interaction.instance.HideText();
            playerOnSpaceship = false;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("GG");
    }
}
