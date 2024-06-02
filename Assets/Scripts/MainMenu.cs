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
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("first_scene");
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