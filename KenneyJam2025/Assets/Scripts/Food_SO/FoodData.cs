using UnityEngine;

[CreateAssetMenu(menuName = "Food/Food")]
public class FoodData : ScriptableObject
{
    public string foodName;
    public Sprite icon;

    [Header("Cooking")] 
    public float cookTime = 5f;
    public GameObject cookedPrefab;
    public int coinRewarded = 5;
}
