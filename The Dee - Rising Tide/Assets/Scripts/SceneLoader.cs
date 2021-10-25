using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject optionsPopup;

    private void Start()
    {
        optionsPopup.SetActive(false);
    }

    public void openOptions()
    {
        optionsPopup.SetActive(true);
    }

    public void closeOptions()
    {
        optionsPopup.SetActive(false);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void quitGame()
    {
        ResetScore();
        Application.Quit();
    }

    public void playAgain()
    {
        ResetScore();
        SceneManager.LoadScene("Game");
    }

    private static void ResetScore()
    {
        GameObject scoreManager = GameObject.Find("ScoreManager");
        Destroy(scoreManager);
    }

    public void mainMenu()
    {
        ResetScore();
        SceneManager.LoadScene(0);
    }

}
