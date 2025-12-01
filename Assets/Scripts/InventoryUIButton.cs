using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text buttonText;

    //set button text to item name
    public void SetButton(Item item)
    {
        buttonText.text = item.name;
    }
}
