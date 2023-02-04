using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform receipeTemplate;

    private void Awake()
    {
        receipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManagerOnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManagerOnRecipeCompleted;

        UpdateVisual();
    }

    private void DeliveryManagerOnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManagerOnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == receipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(receipeTemplate, container);
            receipeTemplate.gameObject.SetActive(true);
            receipeTemplate.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);

        }
    }
}
