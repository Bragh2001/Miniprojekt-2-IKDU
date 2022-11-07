using System.Collections;
using System.Collections.Generic;
using Unity.XR.GoogleVr;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    private int day = 1;
    public Text dayText;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
            FindObjectOfType<ShopManager>().Randomizer();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
            day++;
            dayText.text = "Days: " + day.ToString();
        }
    }

}
