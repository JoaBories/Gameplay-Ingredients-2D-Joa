using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static Interaction instance;
    [SerializeField] TextMeshProUGUI interactionText;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowText(string text)
    {
        gameObject.SetActive(true);
        interactionText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }

}
