using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    // This belongs to all the UI inside fridge's UI panel
    // Every single one of them needs to have this script
    public FoodData foodData;
    public UnityEvent<FoodData> onPicked = new();

    private Image icon;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => onPicked.Invoke(foodData));
        icon = GetComponentInChildren<Image>();
        if (foodData != null && foodData.icon != null)
        {
            icon.sprite = foodData.icon;
        }
    }

    public void OnClick()
    {
        FoodDragManager.Instance.StartDrag(foodData);
    }
}
