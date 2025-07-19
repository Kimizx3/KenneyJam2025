using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Fridge : MonoBehaviour, IPointerClickHandler
{
    // This is the fridge's script
    [Header("Animator")]
    private Animator _animator;
    private bool isOpen = false;

    [Header("UI")] 
    [SerializeField] private Canvas fridgeCanvasPrefab;
    [SerializeField] private Vector3 canvasOffset = new Vector3(0f, 2f, 0f);
    

    private Canvas canvasInstance;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        isOpen = !isOpen;
        _animator.SetTrigger(isOpen ? "Open" : "Close");

        if (isOpen) 
            ShowUI();
        else
            HideUI();
    }

    private void OnFoodPicked(FoodData data)
    {
        HideUI();
        _animator.SetTrigger("Close");
        isOpen = false;

        FoodDragManager.Instance.StartDrag(data);
    }

    private void ShowUI()
    {
        if (canvasInstance == null)
        {
            canvasInstance = Instantiate(fridgeCanvasPrefab, transform);
            canvasInstance.transform.localPosition = canvasOffset;
            canvasInstance.transform.localRotation = Quaternion.identity;
            
            foreach (var slot in canvasInstance.GetComponentsInChildren<FoodUI>())
            {
                slot.onPicked.AddListener(OnFoodPicked);
            }
        }
        canvasInstance.gameObject.SetActive(true);
    }

    private void HideUI()
    {
        if (canvasInstance != null)
        {
            canvasInstance.gameObject.SetActive(false);
        }
    }
}
