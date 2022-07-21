using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultItems : MonoBehaviour
{
    public Item[] items;
    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            Inventory.instance.Add(items[i]);
        }
    }
}
