using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockTile : MonoBehaviour
{
    [SerializeField] private string keyID;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerInventory.Instance.IsInInventory(keyID))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Interaction.instance.ShowText("go get the key");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Interaction.instance.HideText();
    }
}
