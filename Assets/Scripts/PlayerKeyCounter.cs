using UnityEngine;

public class PlayerKeyCounter : MonoBehaviour
{
    public static PlayerKeyCounter Instance;

    private int orangeKeyCounter;
    private int yellowKeyCounter;


    private void Awake()
    {
        Instance = this;
    }

    public void orangeKeyIncrementor()
    {
        orangeKeyCounter++;
        if ( orangeKeyCounter == 3 )
        {
            PlayerInventory.Instance.RemoveItemFromInventory("ORANGE_KEY");
        }
    }

    public void yellowKeyIncrementor()
    {
        yellowKeyCounter++;
        if (yellowKeyCounter == 3)
        {
            PlayerInventory.Instance.RemoveItemFromInventory("YELLOW_KEY");
        }
    }
}
