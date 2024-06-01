using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance { get; set; }
    public TextMeshProUGUI scoreUI;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        UpdateScoreText(); 
        StartCoroutine(IncreaseScoreOverTime());
    }

    void UpdateScoreText()
    {
        scoreUI.text = "" + Mathf.FloorToInt(score);
    }

    System.Collections.IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            score += 1+ PlayerController._forwardSpeed/100;
            UpdateScoreText();
            yield return new WaitForSeconds(0.1f); 
        }
    }
    
    public void ResetScore()
    {
        score = 0;
    }
    
}