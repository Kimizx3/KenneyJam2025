using System;
using UnityEngine;

public class FoodInputHandler : MonoBehaviour
{
    // This handles food dropping on either target machine or wasted
    private void Update()
    {
        if (FoodDragManager.Instance.currentFood == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var receiver = hit.collider.GetComponent<IFoodReceive>();
                if (receiver != null)
                {
                    receiver.TryReceive(FoodDragManager.Instance.currentFood);
                }
            }
            FoodDragManager.Instance.EndDrag();
        }
    }
}
