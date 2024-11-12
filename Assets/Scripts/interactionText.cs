using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interactionText : MonoBehaviour
{
    public static interactionText instance;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowText(string text)
    {
        gameObject.SetActive(true);
        GetComponent<TextMeshProUGUI>().text = text;
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }

}
