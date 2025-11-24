using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text buttonText;


    public void SetButton(Item item)
    {
        buttonText.text = item.name;
    }
}
