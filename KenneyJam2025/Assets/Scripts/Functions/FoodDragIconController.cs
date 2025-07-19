using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodDragIconController : MonoBehaviour
{
    // This script belongs to the DraggedFoodUI prefab
    public static FoodDragIconController Instance { get; private set; }

    [SerializeField] private Image iconImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            iconImage.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(Sprite sprite)
    {
        iconImage.sprite = sprite;
        iconImage.SetNativeSize();
        iconImage.enabled = true;
    }

    public void Hide()
    {
        iconImage.enabled = false;
        iconImage.sprite = null;
    }

    private void Update()
    {
        if (!iconImage.enabled) return;
        transform.position = Input.mousePosition;
    }
}
