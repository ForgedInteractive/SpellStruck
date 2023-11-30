using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static string[] Items = {"Fire", "Ice", "Lightning"};
    public static int Slot = 1;

    private static readonly List<string> Inv = new List<string> {null, null, null};

    public static void AddItem(string item)
    {
        if (Inv.IndexOf(item) == -1)
        {
            Inv.Add(item);
        }
    }

    public static void RemoveItem(string item)
    {
        if (Inv.IndexOf(item) != -1)
        {
            Inv.Remove(item);
        }
    }
    
    public static List<string> GetInv()
    {
        return Inv;
    }

    public static string GetItem(int slot)
    {
        return Inv[slot];
    }
}
