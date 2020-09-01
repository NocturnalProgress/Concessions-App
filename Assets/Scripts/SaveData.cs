using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float totalAmountSold;

    public SaveData(EngineV6 engine)
    {
        totalAmountSold = engine.totalAmount;
    }

}
