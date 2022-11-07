using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[System.Serializable]
public class ShopItem 
{
    public string name;
    public int julekuglePris;
    public Sprite image;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
    
}

public class coin
{

}

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins = 300;
    public List<ShopItem> shopItems;
    public Text coinText;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    public playerMovement player;
    public ShopItem shop = new ShopItem();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Randomizer()
    {
        foreach (var item in shopItems)
        {
            item.julekuglePris = Random.Range(10, 10000);
        }
    }

    void Start()
    {
        
        if (shopItems != null)
        {
            foreach (ShopItem shopItem in shopItems)
            {

                GameObject item = Instantiate(itemPrefab, shopContent);
                shopItem.itemRef = item;


                foreach (Transform child in item.transform)
                {
                    if (child.gameObject.name == "Quantity")
                    {
                        child.gameObject.GetComponent<Text>().text = shopItem.quantity.ToString();
                    }
                    else if (child.gameObject.name == "Price")
                    {
                        child.gameObject.GetComponent<Text>().text = shopItem.julekuglePris.ToString();
                    }
                    else if (child.gameObject.name == "Name")
                    {
                        child.gameObject.GetComponent<Text>().text = shopItem.name;
                    }
                    else if (child.gameObject.name == "Image")
                    {
                        child.gameObject.GetComponent<Image>().sprite = shopItem.image;
                    }
                }

                item.GetComponent<Button>().onClick.AddListener(() =>
                {
                    BuyUpgrade(shopItem);
                });
            }
        }
    }


    public void BuyUpgrade (ShopItem upgrade)
    {
        if (coins >= shop.julekuglePris)
        {
            coins -= shop.julekuglePris;
            upgrade.quantity++;
            upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();
        }
    }

    public void ToggleShop() 
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    void OnGUI()
    {
        coinText.text = "Coins: " + coins.ToString();
    }

}


