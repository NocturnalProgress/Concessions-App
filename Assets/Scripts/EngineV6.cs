using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EngineV6 : MonoBehaviour
{

    // public Canvas setupCanvas;
    // public Canvas applicationCanvas;

    public TMP_InputField itemNameInputField;
    public TMP_InputField itemPriceInputField;
    // public TMP_InputField itemPriceDisplay;
    public TMP_InputField totalAmountDisplay;
    public TMP_InputField totalAmountSoldDisplay;

    public GameObject menuPrefab;
    public GameObject orderPrefab;
    public GameObject statsPrefab;
    public GameObject menuContent;
    public GameObject orderContent;
    public GameObject statsContent;

    public Button getTotalAmountButton;

    private TMP_InputField menuInputField;

    // private CanvasGroup applicationCanvasGroup;
    // private CanvasGroup setupCanvasGroup;

    private Button menuButton;
    private Button orderButton;
    private Button statsButton;

    private GameObject menuButtonGameObject;
    private GameObject orderButtonGameObject;

    private SortedDictionary<string, string> menuItems = new SortedDictionary<string, string>();
    private SortedDictionary<string, string> orderItems = new SortedDictionary<string, string>();
    private SortedDictionary<string, string> statsItems = new SortedDictionary<string, string>();

    private TMP_InputField instantiatedQuantityInputField;

    private string selectedItemName;
    private string selectedItemPrice;
    private string itemNameDictIndex;
    private string value;
    private string item;
    private string itemName;
    private string itemPrice;
    private string priceToChange;
    private string keyToRemove;

    private int quantity;
    private int index;

    public float totalAmount;

    public Toggle removeItemFromMenuToggle;

    public Material buttonColor;

    private string itemToRemove;

    private int imagesIndex;

    private GameObject menuCanvasButtonGroup;

    private float statsTotalAmountSold;

    private string ItemNameToSend;
    private string ItemPriceToSend;
    private string ItemQuantityToSend;
    private string TotalAmountToSend;
    private int OrderNumber;

    void Awake()
    {
        // setupCanvasGroup = setupCanvas.GetComponent<CanvasGroup> ();
        // applicationCanvasGroup = applicationCanvas.GetComponent<CanvasGroup> ();

        menuCanvasButtonGroup = GameObject.Find("MenuCanvas/ButtonGroup");

        OrderNumber = PlayerPrefs.GetInt("orderNumber");
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("orderNumber", OrderNumber);
        PlayerPrefs.Save();
    }

    // void Update () {
    //     if (orderItems.Count <= 0) {
    //         getTotalAmountButton.interactable = false;
    //     } else {
    //         getTotalAmountButton.interactable = true;
    //     }
    // }

    public void OnSubmit()
    {
        if (menuItems.TryGetValue(itemNameInputField.text, out value))
        {
            //  Debug.Log("Item is in dictionary already");
        }
        else
        {
            menuItems.Add(itemNameInputField.text, itemPriceInputField.text);
            string key = itemNameInputField.text;
            menuButtonGameObject = Instantiate(menuPrefab, menuContent.transform, false);
            menuButton = menuButtonGameObject.GetComponentInChildren<Button>(); //  Gets the button in the prefab
            menuButton.onClick.AddListener(MenuButtonFunction); //  Adds function to menuButton
            menuButton.name = key;
            menuButton.transform.parent.name = key;
            menuButton.GetComponentInChildren<TMP_Text>().text = key; //  Adds name to menuButton
            menuInputField = menuButtonGameObject.GetComponentInChildren<TMP_InputField>();
            menuInputField.name = key;
            menuInputField.text = menuItems[key];
            menuInputField.onEndEdit.AddListener(delegate { PriceUpdate(); });
        }
        itemNameInputField.text = "";
        itemPriceInputField.text = "";

        foreach (KeyValuePair<string, string> name in menuItems.OrderBy(key => key.Key))
        {

        }
    }

    public void PriceUpdate()
    {

        keyToRemove = EventSystem.current.currentSelectedGameObject.name;
        priceToChange = menuInputField.text;

        menuItems.Remove(keyToRemove);
        menuItems.Add(keyToRemove, priceToChange);

        if (orderItems.ContainsKey(keyToRemove))
        {
            orderItems.Remove(keyToRemove);
            orderItems.Add(keyToRemove, priceToChange);
        }

        keyToRemove = "";
    }

    public void MenuButtonFunction()
    {
        string itemPriceIndex = EventSystem.current.currentSelectedGameObject.name;

        selectedItemName = EventSystem.current.currentSelectedGameObject.name;
        selectedItemPrice = menuItems[itemPriceIndex];
        //  itemPriceDisplay.text = "$" + selectedItemPrice;

        if (!orderItems.ContainsKey(EventSystem.current.currentSelectedGameObject.name) && !removeItemFromMenuToggle.isOn)
        {
            GameObject orderButtonGameObject = Instantiate(orderPrefab, orderContent.transform, false) as GameObject;
            orderButton = orderButtonGameObject.GetComponentInChildren<Button>();
            orderButton.onClick.AddListener(OrderButtonFunction);
            orderButton.name = selectedItemName;
            orderButton.transform.parent.name = selectedItemName;
            orderButton.GetComponentInChildren<TMP_Text>().text = selectedItemName;
            //  orderButtonGameObject.GetComponentInChildren<TMP_InputField> ().text = "1";
            orderItems.Add(orderButton.transform.parent.name, selectedItemPrice);
        }
        else
        {
            //  Debug.Log(selectedItemName + " is in the order already or you are destroying!");
        }

        if (removeItemFromMenuToggle.isOn == true)
        {

            // Image image = GetComponent<Image>();
            // image.color = new Color32(255, 35, 0, 255);

            GameObject itemToRemove = EventSystem.current.currentSelectedGameObject;

            menuItems.Remove(itemToRemove.name);
            Destroy(itemToRemove.transform.parent.gameObject);

            if (orderItems.ContainsKey(itemToRemove.name))
            {
                orderItems.Remove(itemToRemove.name);
                itemToRemove = GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + itemToRemove.name);
                Destroy(itemToRemove);
                itemToRemove = default(GameObject);
            }
            else
            {
                //  Debug.Log("Item does not exist in orderItems");
            }
        }
        else
        {
            //  Debug.Log("Toggle is off");
            //  Debug.Log(gameObject.name);

            //  GetComponent<Image>().color = new Color32(255, 35, 0, 255);
        }


    }

    public void OrderButtonFunction()
    {
        orderItems.Remove(EventSystem.current.currentSelectedGameObject.name);
        Destroy(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
        selectedItemName = "";
    }

    public void CalculateTotalAmount()
    {
        totalAmount = default(int);

        for (index = 0; index < orderItems.Count; index++)
        {
            itemName = orderItems.ElementAt(index).Key;
            itemPrice = orderItems.ElementAt(index).Value;

            orderButtonGameObject = GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + itemName);
            instantiatedQuantityInputField = orderButtonGameObject.GetComponentInChildren<TMP_InputField>();

            // Debug.Log ("orderButtonGameObject.name: " + orderButtonGameObject.name + "instantiatedQuantityInputField.text: " + instantiatedQuantityInputField.text);
            // Debug.Log ("Name: " + itemName + "Price: " + itemPrice);
            // Debug.Log ("Quantity: " + quantity);

            if (instantiatedQuantityInputField.text == "")
            {
                // Do nothing
            }
            else
            {
                int.TryParse(instantiatedQuantityInputField.text, out quantity);
                totalAmount = totalAmount + (quantity * float.Parse(itemPrice));
                // Debug.Log ("Total: " + totalAmount);
            }

            // Debug.Log ("Index number: " + index + " out of " + "orderItems.Count: " + orderItems.Count);
        }

        totalAmountDisplay.text = "$" + totalAmount.ToString("F2");

        // orderButtonGameObject = default (GameObject);
        // instantiatedQuantityInputField = default (TMP_InputField);
        // itemPrice = default (string);
        // orderButtonGameObject = default (GameObject);
        index = default(int);
        itemName = default(string);

        OrderNumber = OrderNumber + 1;
        Send();
        //  CheckInternetConnection();
        Stats();
    }

    void Stats()
    {
        for (index = 0; index < orderItems.Count; index++)
        {
            string statsItemName = orderItems.ElementAt(index).Key;
            string statsPrice = orderItems.ElementAt(index).Value;
            if (!statsItems.ContainsKey(statsPrice))
            {
                GameObject temp = GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + statsItemName);
                string statsQuantity = temp.GetComponentInChildren<TMP_InputField>().text;
                GameObject statsGameObject = Instantiate(statsPrefab, statsContent.transform, false);
                statsGameObject.name = statsItemName;
                statsGameObject.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = statsItemName;
                GameObject statsQuantityInputField = GameObject.Find("StatsCanvas/StatsScrollView/Viewport/StatsContent/" + statsItemName + "/QuantityInputField");
                statsQuantityInputField.GetComponent<TMP_InputField>().text = statsQuantity;
                GameObject statsPriceInputField = GameObject.Find("StatsCanvas/StatsScrollView/Viewport/StatsContent/" + statsItemName + "/PriceInputField");
                statsPriceInputField.GetComponent<TMP_InputField>().text = "$" + statsPrice;

                statsItems.Add(statsPrice, statsItemName);

                statsTotalAmountSold += (float.Parse(statsPrice) * Convert.ToInt32(statsQuantity));
                totalAmountSoldDisplay.text = statsTotalAmountSold.ToString("F2");
            }
            else
            {
                Debug.Log("Item in statsDictionary already");

                GameObject temp = GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + statsItemName);
                int statsQuantity = Convert.ToInt32(temp.GetComponentInChildren<TMP_InputField>().text);
                GameObject statsQuantityInputField = GameObject.Find("StatsCanvas/StatsScrollView/Viewport/StatsContent/" + statsItemName + "/QuantityInputField");
                int currentStatsQuantity = Convert.ToInt32(statsQuantityInputField.GetComponent<TMP_InputField>().text);
                statsQuantityInputField.GetComponent<TMP_InputField>().text = (currentStatsQuantity + statsQuantity).ToString();

                statsTotalAmountSold += (float.Parse(statsPrice) * Convert.ToInt32(statsQuantity));
                totalAmountSoldDisplay.text = statsTotalAmountSold.ToString("F2");
            }
        }

        for (index = 0; index < orderItems.Count; index++)
        {
            string statsItemName = orderItems.ElementAt(index).Key;
            Destroy(GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + statsItemName));
        }

        orderItems.Clear();
    }

    public void RemoveItemFromMenu()
    {
        if (removeItemFromMenuToggle.isOn == true)
        {
            menuCanvasButtonGroup.SetActive(false);

            for (index = 0; index < menuItems.Count; index++)
            {
                itemToRemove = menuItems.ElementAt(index).Key;

                GameObject itemGameObject = GameObject.Find("MenuCanvas/MenuScrollView/Viewport/MenuContent/" + itemToRemove);
                itemGameObject.GetComponentInChildren<Image>().color = new Color32(255, 35, 0, 255);
                itemGameObject.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().color = Color.black;
                itemGameObject.GetComponentInChildren<TMP_InputField>().interactable = false;
            }
        }

        if (removeItemFromMenuToggle.isOn == false)
        {
            menuCanvasButtonGroup.SetActive(true);

            if (menuItems.Count > 0)
            {
                for (index = 0; index < menuItems.Count; index++)
                {
                    itemToRemove = menuItems.ElementAt(index).Key;

                    GameObject itemGameObject = GameObject.Find("MenuCanvas/MenuScrollView/Viewport/MenuContent/" + itemToRemove);
                    itemGameObject.GetComponentInChildren<Image>().color = new Color32(0, 17, 70, 255);
                    itemGameObject.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().color = new Color32(255, 223, 0, 255);
                    itemGameObject.GetComponentInChildren<TMP_InputField>().interactable = true;
                }
            }
        }
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        Debug.Log(data.totalAmountSold);
    }

    public void CheckInternetConnection()
    {
        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
            {
                Debug.Log("Internet Available!");
            }
            else
            {
                Debug.Log("Internet Not Available");
            }
        }));
    }

    IEnumerator CheckInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com/forms/about/");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error");
            action(false);
        }
        else
        {
            Debug.Log("Success");
            action(true);
        }
    }


    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSffFlx2xi2Aw-I5AetaANlHcbpOu2OlT3s2hcUCRqd5p-dOTw/formResponse";


    IEnumerator Post(string orderNumber, string itemNameToSend, string itemPriceToSend, string itemQuantityToSend, string totalAmountToSend)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1456422626", orderNumber); //Order Number
        form.AddField("entry.363141167", itemNameToSend); // Item Name
        form.AddField("entry.6291551", itemPriceToSend); // Price
        form.AddField("entry.1415669023", itemQuantityToSend); // Quantiy
        form.AddField("entry.15141244", totalAmountToSend); // Total Amount

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

    }
    public void Send()
    {
        for (index = 0; index < orderItems.Count; index++)
        {
            ItemNameToSend = orderItems.ElementAt(index).Key;

            ItemPriceToSend = orderItems.ElementAt(index).Value;

            orderButtonGameObject = GameObject.Find("OrderCanvas/OrderScrollView/Viewport/OrderContent/" + itemName);
            instantiatedQuantityInputField = orderButtonGameObject.GetComponentInChildren<TMP_InputField>();
            ItemQuantityToSend = instantiatedQuantityInputField.text;
            TotalAmountToSend = totalAmountDisplay.text;

            // if (index == 0)
            // {
            //     TotalAmountToSend = totalAmountDisplay.text;
            // }
            // else
            // {
            //     TotalAmountToSend = "";
            // }

            Debug.Log("Index: " + index + " ItemNameToSend: " + ItemNameToSend + " ItemPriceToSend: " + ItemPriceToSend + " ItemQuantityToSend: " + ItemQuantityToSend + " TotalAmountToSend: " + TotalAmountToSend);

            StartCoroutine(Post(OrderNumber.ToString(), ItemNameToSend, ItemPriceToSend, ItemQuantityToSend, TotalAmountToSend));
        }
    }
}
