using System;
using TMPro;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private PlayerController player;

    public void UpdateScore()
    {
        text.text = $"{player.score}";
    }

    public void UpdateText()
    {
        text.text = $"{++player.score}";
    }

   
}
