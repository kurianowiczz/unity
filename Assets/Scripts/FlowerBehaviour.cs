using TMPro;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    private FlowerManager flowerManager;

    private void Start()
    {
        
          flowerManager = transform.parent.GetComponent<FlowerManager>();
      
    }

    private void OnTriggerEnter(Collider other)
    {
        flowerManager.UpdateText();
        gameObject.SetActive(false);
    }
}
