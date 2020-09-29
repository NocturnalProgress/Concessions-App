using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class EngineV4 : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject orderPrefab;
    public GameObject menuContent;
    public GameObject orderContent;
    public TMP_InputField itemNameInputField;
    public TMP_InputField itemPriceInputField;
    public TMP_InputField itemPriceDisplay;
    public TMP_InputField totalAmountDisplay;
    public Canvas setupCanvas;
    public Canvas applicationCanvas;
    private CanvasGroup setupCanvasGroup;
    private CanvasGroup applicationCanvasGroup;
    private GameObject menuButtonGameObject; //A menu button addes the item to the order
    private GameObject orderButtonGameObject; //An order button removes the item from the order
    private List<string> itemNameList = new List<string>();
    private List<string> itemPriceList = new List<string>();
    private List<GameObject> removeFromOrderList = new List<GameObject>();
    private List<string> itemOrderList = new List<string>();
    private int itemNameListIndex;
    private int testCount;
    private string selectedItemPrice;
    private string selectedItemName;
    private int quantity;
    private float totalAmount;
    private int itemNameListCount;
    private string orderButtonName;
    private TMP_Text menuButtonText;
    private Button menuButton;
    private Button orderButton;
    private TMP_InputField quantityInputField;
    private int itemOrderListCount;
    private int itemOrderListIndex;
    private string itemToOrder;
    private int itemToOrderIndex;
    private int getIndexFromItemOrderList;
    private string itemNameFromItemNameList;
    private int getIndexFromItemName;
    private string itemToOrderPrice;

    private int calculateTotalPriceCount;
    private string nameofItemToPriceCalculate;
    private GameObject gameObjectOfItemToPriceCalculate;
    private string quantityfromGameObjectToPriceCalculate;
    private string nameOfItemToGetPriceFrom;
    private int indexToGetItemPrice;
    private string itemPriceToCalculateTotalAmount;

    private int indexOfItemToRemove;


    void Start()
    {
        applicationCanvasGroup = applicationCanvas.GetComponent<CanvasGroup>();
        setupCanvasGroup = setupCanvas.GetComponent<CanvasGroup>();
    }

    public void displayAppSetup()
    {
        applicationCanvasGroup.alpha = 0;
        applicationCanvasGroup.interactable = false;
        applicationCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 1;
        setupCanvasGroup.interactable = true;
        setupCanvasGroup.blocksRaycasts = true;
    }

    public void displayApplication() //onFinished
    {
        applicationCanvasGroup.alpha = 1;
        applicationCanvasGroup.interactable = true;
        applicationCanvasGroup.blocksRaycasts = true;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        foreach (string option in itemNameList)
        {
            GameObject menuButtonGameObject = Instantiate(itemPrefab, menuContent.transform, false) as GameObject;
            menuButton = menuButtonGameObject.GetComponentInChildren<Button>(); //Gets the button in the prefab
            menuButton.onClick.AddListener(menuButtonFunction); //Adds function to menuButton
            menuButton.name = itemNameList[itemNameListCount];
            menuButton.GetComponentInChildren<TMP_Text>().text = itemNameList[itemNameListCount]; //Adds name to menuButton
            itemNameListCount++;
        }
    }

    public void onSubmit()
    {
        itemNameList.Add(itemNameInputField.text);
        itemPriceList.Add(itemPriceInputField.text.ToString());

        itemNameInputField.text = "";
        itemPriceInputField.text = "";

    }

    public void menuButtonFunction()
    {
        itemNameListIndex = itemNameList.FindIndex(a => a.Contains(EventSystem.current.currentSelectedGameObject.name)); //Finds the INDEX of the name of the menuButton


        selectedItemName = itemNameList[itemNameListIndex];
        selectedItemPrice = itemPriceList[itemNameListIndex];
        itemPriceDisplay.text = "$" + selectedItemPrice;


        if (!itemOrderList.Contains(selectedItemName)) // If the item isn't in the order already then add it
        {
            GameObject orderButtonGameObject = Instantiate(orderPrefab, orderContent.transform, false) as GameObject;
            orderButton = orderButtonGameObject.GetComponentInChildren<Button>();
            orderButton.onClick.AddListener(orderButtonFunction);
            orderButton.name = selectedItemName;
            orderButton.transform.parent.name = selectedItemName;
            orderButton.GetComponentInChildren<TMP_Text>().text = selectedItemName;
            itemOrderList.Add(orderButton.transform.parent.name);

            quantityInputField = orderButtonGameObject.GetComponentInChildren<TMP_InputField>();
            quantityInputField.onValueChanged.AddListener(delegate { displayTotalAmount(); });
        }
        else
        {
            Debug.Log(selectedItemName + " is in the order already!");
        }
    }

    public void orderButtonFunction()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        indexOfItemToRemove = itemOrderList.FindIndex(a => a.Contains(EventSystem.current.currentSelectedGameObject.name));
        itemOrderList.RemoveAt(indexOfItemToRemove);
        //  itemOrderList.Remove(selectedItemName);

        Destroy(orderButton.transform.parent.gameObject);
        selectedItemName = "";
    }

    public void displayTotalAmount()
    {

    }

    public void calculateTotalAmount()
    {

        foreach (string option in itemOrderList)
        {
            nameofItemToPriceCalculate = itemOrderList[calculateTotalPriceCount];
            GameObject gameObjectOfItemToPriceCalculate = GameObject.Find("ApplicationCanvas/OrderScrollView/Viewport/OrderContent/" + nameofItemToPriceCalculate);
            TMP_InputField instantiatedQuantityInputField = gameObjectOfItemToPriceCalculate.GetComponentInChildren<TMP_InputField>();
            quantityfromGameObjectToPriceCalculate = instantiatedQuantityInputField.text;
            nameOfItemToGetPriceFrom = gameObjectOfItemToPriceCalculate.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text;
            indexToGetItemPrice = itemOrderList.FindIndex(a => a.Contains(nameOfItemToGetPriceFrom));
            itemPriceToCalculateTotalAmount = itemPriceList[indexToGetItemPrice];
            quantity = int.Parse(quantityfromGameObjectToPriceCalculate);
            int.TryParse(quantityfromGameObjectToPriceCalculate, out quantity); //Turns the number from the instantiated gameObject into quanity
                                                                                //  Debug.Log("quantity:" + quantity);
            totalAmount = totalAmount + (quantity * float.Parse(itemPriceToCalculateTotalAmount));
            calculateTotalPriceCount++;
        }
        totalAmountDisplay.text = "$" + totalAmount.ToString("F2");

    }
}
