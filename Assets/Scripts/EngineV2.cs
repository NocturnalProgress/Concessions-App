using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class EngineV2 : MonoBehaviour
{

    // public TMP_Dropdown dropdown;
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

        // Debug.Log(itemNameList[testCount]);
        // Debug.Log(itemPriceList[testCount]);
        /*
                for (int i = itemNameList.Count; i < itemNameList.Count; i++)
                {
                    dropdown.options.Add(new TMP_Dropdown.OptionData(itemNameList[itemNameListCount]));
                    itemNameListCount++;
                }
        */



        // GameObject button = Instantiate(itemPrefab, content.transform, false) as GameObject;

        //Move this to when the finished button is clicked?
        //Foreach loop not required unless the buttons are added when clicked finished instead of submit
        //If it is moved to the finished button then the itemNameList can be sorted A-Z to make it easier to find stuff
        //Need to combine Coordinator.cs and Engine.cs to use the finished button
        /* foreach (string option in itemNameList)
         {
             button.GetComponentInChildren<TMP_Text>().text = itemNameList[itemNameListCount];
             itemNameListCount++;
         }
        */

        //  button.GetComponentInChildren<TMP_Text>().text = itemNameList[itemNameListCount];
        //  itemNameListCount++;


    }
    public void menuButtonFunction()
    {
        // itemNameListIndex = itemNameList.FindIndex(a => a.Contains(dropdown.options[dropdown.value].text));
        // Debug.Log(itemNameListIndex);
        // Debug.Log("$" + itemPriceList[itemNameListIndex]);

        /*
                orderButtonName = menuButton.GetComponentInChildren<TMP_Text>().text;
                GameObject orderButton = Instantiate(itemPrefab, orderContent.transform, false) as GameObject;
                orderButton.GetComponentInChildren<Button>().onClick.AddListener(orderButtonFunction);
                orderButton.GetComponentInChildren<TMP_Text>().text = orderButtonName;
                orderButtonName = "";
                // button.GetComponentInChildren<TMP_Text>().text = "test";
                Debug.Log(orderButton.GetComponentInChildren<TMP_Text>().text);
               
                //  itemOrderList.Add(itemNameList[itemNameListIndex]);
        */
        itemNameListIndex = itemNameList.FindIndex(a => a.Contains(EventSystem.current.currentSelectedGameObject.name)); //Finds the INDEX of the name of the menuButton


        selectedItemName = itemNameList[itemNameListIndex];
        selectedItemPrice = itemPriceList[itemNameListIndex];
        itemPriceDisplay.text = "$" + selectedItemPrice;


        if (!itemOrderList.Contains(selectedItemName)) // If the item isn't in the order already then add it
        {
            GameObject orderButtonGameObject = Instantiate(orderPrefab, orderContent.transform, false) as GameObject;
            orderButton = orderButtonGameObject.GetComponentInChildren<Button>();
            orderButton.onClick.AddListener(orderButtonFunction);
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
        /*
                Debug.Log("EventSystem: " + EventSystem.current.currentSelectedGameObject.name);
                Debug.Log("menuButton.name: " + menuButton.name);
                Debug.Log("itemNameListIndex: " + itemNameListIndex);
                Debug.Log("menuButtonText: " + this.menuButton.GetComponentInChildren<TMP_Text>().text);
                Debug.Log("selectedItemName: " + selectedItemName);
        */
    }

    public void orderButtonFunction()
    {
        /*
         removeFromOrderList.Add(this.orderButton.gameObject);
         Debug.Log(removeFromOrderList[0]);
         foreach (GameObject button in removeFromOrderList)
         {
             Destroy(button.gameObject);
         }
         */
    }

    public void displayTotalAmount()
    {

        /*
                foreach (string option in itemOrderList)
                {
                    Debug.Log(itemOrderList[itemOrderListCount]);
                    itemOrderListCount++;
                }
        */

        /*    while (itemOrderListCount <= itemOrderList.Count)
            {
                itemToOrder = itemOrderList[itemOrderListCount];
                itemToOrderIndex = itemNameList.FindIndex(a => a.Contains(itemToOrder));
                itemNameFromItemNameList = itemNameList[itemToOrderIndex];
                getIndexFromItemName = itemNameList.FindIndex(a => a.Contains(itemToOrder));
                itemToOrderPrice = itemPriceList[getIndexFromItemName];
                //   totalAmount = totalAmount + 
                Debug.Log(itemToOrderPrice);
                itemOrderListCount++;
            }

            if (itemOrderListCount == itemOrderList.Count)
            {

            }

            /*foreach (string option in itemOrderList)
            {
                int index = transform.GetSiblingIndex();
                itemToOrder = transform.parent.GetChild(index + 1).gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text;
                itemToOrderIndex = itemNameList.FindIndex(a => a.Contains(itemToOrder));
                itemNameFromItemNameList = itemNameList[itemToOrderIndex];
                getIndexFromItemName = itemNameList.FindIndex(a => a.Contains(itemToOrder));
                itemToOrderPrice = itemPriceList[getIndexFromItemName];
                Debug.Log(itemToOrderPrice);

                //Get each item name from the list and put it into the item list to get the index FROM the item order list then put it into the item price list
            }
            */
        // quantity = int.Parse(quantityInputField.text);
        /*  int.TryParse(quantityInputField.text, out quantity);
          totalAmount = quantity * float.Parse(selectedItemPrice);
          totalAmountDisplay.text = "$" + totalAmount.ToString("F2");
  */
    }

    public void calculateTotalAmount()
    {
        nameofItemToPriceCalculate = itemOrderList[calculateTotalPriceCount];
        //  Debug.Log("nameofItemToPriceCalculate: " + nameofItemToPriceCalculate);
        GameObject gameObjectOfItemToPriceCalculate = GameObject.Find("ApplicationCanvas/OrderScrollView/Viewport/OrderContent/" + nameofItemToPriceCalculate);
        //  Debug.Log("gameObjectOfItemToPriceCalculate: " + gameObjectOfItemToPriceCalculate);
        TMP_InputField instantiatedQuantityInputField = gameObjectOfItemToPriceCalculate.GetComponentInChildren<TMP_InputField>();
        quantityfromGameObjectToPriceCalculate = instantiatedQuantityInputField.text;
        nameOfItemToGetPriceFrom = gameObjectOfItemToPriceCalculate.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text;
        indexToGetItemPrice = itemOrderList.FindIndex(a => a.Contains(nameOfItemToGetPriceFrom));
        itemPriceToCalculateTotalAmount = itemPriceList[indexToGetItemPrice];
        //  Debug.Log("itemPriceToCalculateTotalAmount: " + itemPriceToCalculateTotalAmount);
        quantity = int.Parse(quantityfromGameObjectToPriceCalculate);
        int.TryParse(quantityfromGameObjectToPriceCalculate, out quantity); //Turns the number from the instantiated gameObject into quanity
        //  Debug.Log("quantity:" + quantity);
        totalAmount = quantity * float.Parse(itemPriceToCalculateTotalAmount);
        totalAmountDisplay.text = "$" + totalAmount.ToString("F2");
    }
}
