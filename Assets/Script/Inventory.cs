using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;

    public bool[] items = { false, false };
    public int[] collectables = { 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        inventory = this;
    }

    // Update is called once per frame
    public void AddItem (string ItemiD)
    {
        if(ItemiD == TagManager.lilin)
        {
            items[0] = true;
        }
        if (ItemiD == TagManager.key)
        {
            collectables[0]++;
        }
        Debug.Log(ItemiD + " Addedd");
    }
}
