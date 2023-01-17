using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeItem : MonoBehaviour
{
    public string itemName; // The name of the item

    private bool hasBeenUsed = false; // Whether the item has been used or not

    void Start()
    {
        // Check if the item has been used before
        if (PlayerPrefs.HasKey(itemName))
        {
            hasBeenUsed = PlayerPrefs.GetInt(itemName) == 1;
        }

        if (hasBeenUsed)
        {
            // If the item has been used before, destroy it
            Destroy(gameObject);
        }
    }

    public void UseItem()
    {
        if (!hasBeenUsed)
        {
            // Code to handle item usage
            Debug.Log("Used " + itemName);
            hasBeenUsed = true;
            PlayerPrefs.SetInt(itemName, 1);
            Destroy(gameObject);
        }
    }
}
