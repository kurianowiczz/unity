using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text numWinPlayertext;
    [SerializeField] private Button button;
    
    [SerializeField] private PlayerController firstPlayer;
    [SerializeField] private PlayerController secondPlayer;

    [SerializeField] private FlowerManager firstScoreManager;
    [SerializeField] private FlowerManager secondScoreManager;


    [SerializeField] private float timeRemaining = 10;

    private float currentTime;
    private bool isStop = false;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            RestartSettings();
        });
    }

    private void RestartSettings()
    {
        Manager.instance.Restart();
        PlayerController.isStop = false;

        currentTime = timeRemaining;

        button.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        numWinPlayertext.gameObject.SetActive(false);

        firstPlayer.score = 0;
        secondPlayer.score = 0;
        firstScoreManager.UpdateScore();
        secondScoreManager.UpdateScore();
    }

    private void Start()
    {
        currentTime = timeRemaining;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0);
        DisplayTime(currentTime);
        

        if (currentTime == 0)
        {
            if (isStop) return;
            PlayerController.isStop = true;
            button.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);

            int firstScore = firstPlayer.score;
            int secondScore = secondPlayer.score;
            if (secondScore > firstScore)
            {
                numWinPlayertext.text = "2";
            }
            else if (secondScore == firstScore)
            {
                numWinPlayertext.text = "1 and 2";
            }
            else
            {
                numWinPlayertext.text = "1";
            }
            numWinPlayertext.gameObject.SetActive(true);

            DisplayTime(0);
        }
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds); ;
    }
}
