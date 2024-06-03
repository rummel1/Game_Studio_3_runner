using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialMenu;
    public GameObject leaderboard;

    public GameObject AthensShip;
    public GameObject speedbar;
    public GameObject score;
    public GameObject sound;

    private void Start()
    {
        speedbar.SetActive(false);
        score.SetActive(false);
        AthensShip.SetActive(false);
    }

    public void PlayGame()
    {
        
        sound.SetActive(true);
        AthensShip.SetActive(true);
        speedbar.SetActive(true);
        score.SetActive(true);
        mainMenu.SetActive(false);
        ScoreSystem.instance.ResetScore();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void TutorialMenu()
    {
        tutorialMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void BackSettingsButton()
    {
        tutorialMenu.SetActive(false);
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LeaderboardButton()
    {
        leaderboard.SetActive(true);
        mainMenu.SetActive(false);
    }
}