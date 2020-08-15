using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EngineV3 : MonoBehaviour
{

    public TMP_Dropdown dropdown;

    public Button itemPrefab;

    public TMP_InputField itemNameInputField;
    public TMP_InputField itemPriceInputField;
    public TMP_InputField itemPriceDisplay;
    public TMP_InputField quantityInputField;
    public TMP_InputField totalAmountDisplay;

    private List<string> itemNameList = new List<string>();
    private List<string> itemPriceList = new List<string>();

    private int itemNameListIndex;

    private int testCount;

    private string selectedItemPrice;
    private string selectedItem;
    private int quantity;
    private float totalAmount;

    public void onSubmit()
    {
        itemNameList.Add(itemNameInputField.text);
        itemPriceList.Add(itemPriceInputField.text.ToString());

        itemNameInputField.text = "";
        itemPriceInputField.text = "";

        Debug.Log(itemNameList[testCount]);
        Debug.Log(itemPriceList[testCount]);

        testCount++;

        /*
                for (int i = itemNameList.Count; i < itemNameList.Count; i++)
                {
                    dropdown.options.Add(new TMP_Dropdown.OptionData(itemNameList[itemNameListCount]));
                    itemNameListCount++;
                }
        */
        dropdown.options.Clear();
        foreach (string option in itemNameList)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }
    }

    public void displayPrice()
    {
        itemNameListIndex = itemNameList.FindIndex(a => a.Contains(dropdown.options[dropdown.value].text));
        // Debug.Log(itemNameListIndex);
        // Debug.Log("$" + itemPriceList[itemNameListIndex]);

        selectedItemPrice = itemPriceList[itemNameListIndex];

        itemPriceDisplay.text = "$" + selectedItemPrice;
    }

    public void displayTotalAmount()
    {

        // quantity = int.Parse(quantityInputField.text);
        int.TryParse(quantityInputField.text, out quantity);
        totalAmount = quantity * float.Parse(selectedItemPrice);
        totalAmountDisplay.text = "$" + totalAmount.ToString("F2");

    }
}