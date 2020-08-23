using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EngineV5 : MonoBehaviour {

    public Canvas setupCanvas;
    public Canvas applicationCanvas;

    public TMP_InputField itemNameInputField;
    public TMP_InputField itemPriceInputField;
    public TMP_InputField itemPriceDisplay;
    public TMP_InputField totalAmountDisplay;

    public GameObject menuPrefab;
    public GameObject orderPrefab;
    public GameObject menuContent;
    public GameObject orderContent;

    public Button getTotalAmountButton;

    private TMP_InputField menuInputField;

    private CanvasGroup applicationCanvasGroup;
    private CanvasGroup setupCanvasGroup;

    private Button menuButton;
    private Button orderButton;

    private GameObject menuButtonGameObject;
    private GameObject orderButtonGameObject;

    private SortedDictionary<string, string> menuItems = new SortedDictionary<string, string> ();
    private SortedDictionary<string, string> orderItems = new SortedDictionary<string, string> ();

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

    private float totalAmount;

    void Awake () {
        setupCanvasGroup = setupCanvas.GetComponent<CanvasGroup> ();
        applicationCanvasGroup = applicationCanvas.GetComponent<CanvasGroup> ();
    }

    // void Update () {
    //     if (orderItems.Count <= 0) {
    //         getTotalAmountButton.interactable = false;
    //     } else {
    //         getTotalAmountButton.interactable = true;
    //     }
    // }

    public void OnSubmit () {
        if (menuItems.TryGetValue (itemNameInputField.text, out value)) {
            Debug.Log ("Item is in dictionary already");
        } else {
            menuItems.Add (itemNameInputField.text, itemPriceInputField.text);
            string key = itemNameInputField.text;
            menuButtonGameObject = Instantiate (menuPrefab, menuContent.transform, false);
            menuButton = menuButtonGameObject.GetComponentInChildren<Button> (); //Gets the button in the prefab
            menuButton.onClick.AddListener (MenuButtonFunction); //Adds function to menuButton
            menuButton.name = key;
            menuButton.GetComponentInChildren<TMP_Text> ().text = key; //Adds name to menuButton
            menuInputField = menuButtonGameObject.GetComponentInChildren<TMP_InputField> ();
            menuInputField.name = key;
            menuInputField.text = menuItems[key];
            menuInputField.onEndEdit.AddListener (delegate { PriceUpdate (); });
        }
        itemNameInputField.text = "";
        itemPriceInputField.text = "";
    }

    public void PriceUpdate () {

        keyToRemove = EventSystem.current.currentSelectedGameObject.name;
        priceToChange = menuInputField.text;

        menuItems.Remove (keyToRemove);
        menuItems.Add (keyToRemove, priceToChange);

        if (orderItems.ContainsKey (keyToRemove)) {
            orderItems.Remove (keyToRemove);
            orderItems.Add (keyToRemove, priceToChange);
        }

        keyToRemove = "";
    }

    public void MenuButtonFunction () {
        string itemPriceIndex = EventSystem.current.currentSelectedGameObject.name;

        selectedItemName = EventSystem.current.currentSelectedGameObject.name;
        selectedItemPrice = menuItems[itemPriceIndex];
        itemPriceDisplay.text = "$" + selectedItemPrice;

        if (!orderItems.ContainsKey (EventSystem.current.currentSelectedGameObject.name)) {
            GameObject orderButtonGameObject = Instantiate (orderPrefab, orderContent.transform, false) as GameObject;
            orderButton = orderButtonGameObject.GetComponentInChildren<Button> ();
            orderButton.onClick.AddListener (orderButtonFunction);
            orderButton.name = selectedItemName;
            orderButton.transform.parent.name = selectedItemName;
            orderButton.GetComponentInChildren<TMP_Text> ().text = selectedItemName;
            //  orderButtonGameObject.GetComponentInChildren<TMP_InputField> ().text = "1";
            orderItems.Add (orderButton.transform.parent.name, selectedItemPrice);
        } else {
            Debug.Log (selectedItemName + " is in the order already!");
        }
    }

    public void orderButtonFunction () {
        orderItems.Remove (EventSystem.current.currentSelectedGameObject.name);
        Destroy (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
        selectedItemName = "";
    }

    public void CalculateTotalAmount () {
        totalAmount = default (int);

        for (index = 0; index < orderItems.Count; index++) {
            itemName = orderItems.ElementAt (index).Key;
            itemPrice = orderItems.ElementAt (index).Value;

            orderButtonGameObject = GameObject.Find ("ApplicationCanvas/OrderScrollView/Viewport/OrderContent/" + itemName);
            instantiatedQuantityInputField = orderButtonGameObject.GetComponentInChildren<TMP_InputField> ();

            // Debug.Log ("orderButtonGameObject.name: " + orderButtonGameObject.name + "instantiatedQuantityInputField.text: " + instantiatedQuantityInputField.text);
            // Debug.Log ("Name: " + itemName + "Price: " + itemPrice);
            // Debug.Log ("Quantity: " + quantity);

            if (instantiatedQuantityInputField.text == "") {
                quantity = 1;
                totalAmount = totalAmount + (quantity * float.Parse (itemPrice));
                totalAmount = totalAmount - totalAmount;
                // Debug.Log ("Total: " + totalAmount);
            } else {
                int.TryParse (instantiatedQuantityInputField.text, out quantity);
                totalAmount = totalAmount + (quantity * float.Parse (itemPrice));
                // Debug.Log ("Total: " + totalAmount);
            }

            // Debug.Log ("Index number: " + index + " out of " + "orderItems.Count: " + orderItems.Count);
        }

        totalAmountDisplay.text = "$" + totalAmount.ToString ("F2");

        // orderButtonGameObject = default (GameObject);
        // instantiatedQuantityInputField = default (TMP_InputField);
        index = default (int);
        itemName = default (string);
        // itemPrice = default (string);

        // orderButtonGameObject = default (GameObject);

    }

    // public void DisplayApplication () {
    //     applicationCanvasGroup.alpha = 1;
    //     applicationCanvasGroup.interactable = true;
    //     applicationCanvasGroup.blocksRaycasts = true;

    //     setupCanvasGroup.alpha = 0;
    //     setupCanvasGroup.interactable = false;
    //     setupCanvasGroup.blocksRaycasts = false;
    // }

    // public void DisplaySetup () {
    //     applicationCanvasGroup.alpha = 0;
    //     applicationCanvasGroup.interactable = false;
    //     applicationCanvasGroup.blocksRaycasts = false;

    //     setupCanvasGroup.alpha = 1;
    //     setupCanvasGroup.interactable = true;
    //     setupCanvasGroup.blocksRaycasts = true;
    // }
}