using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static Sprite _slotImg;
    private static Sprite _selSlotImg;

    private void Awake()
    {
        _slotImg = Resources.Load<Sprite>("Sprites/UI/grey_button08");
        _selSlotImg = Resources.Load<Sprite>("Sprites/UI/blue_button06");
    }

    private void Start()
    {
        UpdateUI();
    }

    private void OnSlot1(InputValue value)
    {
        Inventory.Slot = 1;
        UpdateUI();
    }
    private void OnSlot2(InputValue value)
    {
        Inventory.Slot = 2;
        UpdateUI();
    }
    private void OnSlot3(InputValue value)
    {
        Inventory.Slot = 3;
        UpdateUI();
    }

    private void OnSlotLeft(InputValue value)
    {
        if (Inventory.Slot > 1)
        {
            Inventory.Slot--;
        }
        else
        {
            Inventory.Slot = 3;
        }
        UpdateUI();
    }
    private void OnSlotRight(InputValue value)
    {
        if (Inventory.Slot < 3)
        {
            Inventory.Slot++;
        }
        else
        {
            Inventory.Slot = 1;
        }
        UpdateUI();
    }

    public static void UpdateUI()
    {
        //inventory slots
        for (int i = 0; i < 3; i++)
        {
            var item = Inventory.GetItem(i);
            if (item != null)
            {
                
            }
        }

        foreach (var slot in GameObject.Find("Hotbar").GetComponentsInChildren<Image>())
        {
            slot.sprite = _slotImg;
        }

        GameObject.Find("Hotbar").GetComponentsInChildren<Image>()[Inventory.Slot - 1].sprite = _selSlotImg;
    }
}
