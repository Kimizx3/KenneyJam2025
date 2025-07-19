using System;
using UnityEngine;

public class FoodDragManager : MonoBehaviour
{
    // Tracks which icon is being dragged right now, and handles start/end drag logics
    public static FoodDragManager Instance { get; private set; }

    public FoodData currentFood;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnsureDragUIExists();
    }

    private void EnsureDragUIExists()
    {
        if (FoodDragIconController.Instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>("UI/DraggedFoodUI");
            Instantiate(prefab);
        }
    }

    public void StartDrag(FoodData data)
    {
        EnsureDragUIExists();
        currentFood = data;
        FoodDragIconController.Instance.Show(data.icon);
        Cursor.visible = false;
    }

    public void EndDrag()
    {
        currentFood = null;
        FoodDragIconController.Instance.Hide();
        Cursor.visible = true;
    }
}
