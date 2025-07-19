using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OvenReceiver : MonoBehaviour, IFoodReceive
{
    // This belongs to any machine that receives targeted food icon

    [SerializeField] private Transform spawnPoint; // for cooked steak
    [SerializeField] private Canvas progressCanvas; // World-Space, progress bar under it
    [SerializeField] private Image progressBar;

    private bool isBusy = false;
    
    public bool TryReceive(FoodData foodData)
    {
        if (isBusy || foodData.cookedPrefab == null) return false;
        
        Debug.Log($"{foodData.name}");
        return true;
    }

    private IEnumerator CookRoutine(FoodData foodData)
    {
        isBusy = true;
        progressBar.gameObject.SetActive(true);

        float t = 0, duration = foodData.cookTime;
        while (t < duration)
        {
            t += Time.deltaTime;
            progressBar.fillAmount = t / duration;
            yield return null;
        }
        
        progressCanvas.gameObject.SetActive(false);

        var cooked = Instantiate(foodData.cookedPrefab, spawnPoint.position, Quaternion.identity);
        var item = cooked.AddComponent<CollectableFood>();
        item.Setup(foodData);

        isBusy = false;
    }
}
