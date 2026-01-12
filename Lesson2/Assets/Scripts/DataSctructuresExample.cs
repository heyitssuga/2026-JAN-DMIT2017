using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class DataSctructuresExample : MonoBehaviour
{
    int i;
    float o;
    string s;
    char c;

    float maxSpeed;
    
    // arrays, lists, dictionaries, hash tables
    // public InventoryItem[] inventory;
    public List<InventoryItem> inventory;

    public Dictionary<InventoryItem, int> inventoryDictionary = new Dictionary<InventoryItem, int>();
    public int[] ints;

    private void Start()
    {
        InventoryItem shield = new InventoryItem();
        shield.itemName = "Shield";
        shield.weight = 10;
        shield.durability = 10;
        shield.dmg = 0;
        
        // foreach (InventoryItem item in
        //          inventory)
        // {
        //     if (item.itemName ==
        //         shield.itemName)
        //     {
        //         return;
        //     }
        // }
        // inventory.Add(shield);
        
        AddItem(shield);
        AddItem(shield);

        
    }

    public void AddItem(InventoryItem item)
    {
        if (inventoryDictionary.ContainsKey(item))
        {
            inventoryDictionary[item]++;
        }
        else
        {
            inventoryDictionary.Add(item, 1);
        }
        
        // if (inventoryDictionary.TryAdd(item, 1) == false)
        // {
        //     inventoryDictionary[item] = inventoryDictionary[item]++;
        // }
        Debug.Log(item.itemName + " count = " + inventoryDictionary[item]);
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int weight;
    public int dmg;
    public int durability;
}

public class Profile
{
    public int highscore;
    public string profileName;
    VehicleColor vehiclecolor;
    GameObject vehicle;
}

public enum VehicleColor
{
    WHITE,
    BLACK,
    RED,
    PURPLE,
    BLUE
}
