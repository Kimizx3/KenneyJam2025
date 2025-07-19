using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class CollectableFood : MonoBehaviour
{
    private FoodData _data;

    public void Setup(FoodData foodData) => _data = foodData;

    public void OnPointerClick(PointerEventData eventData)
    {
        MoneyManager.Instance.AddCoins(_data.coinRewarded);
        Destroy(gameObject);
    }
}
