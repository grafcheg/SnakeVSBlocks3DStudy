using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject gameScreen;
    public Text levelText;

    private int currentSceneIndex;
    
    public enum State
    {
        Play,
        Win,
        Loss,
    }
    
    public State CurrentState { get; private set; }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level " + (currentSceneIndex + 1);
    }
    
    public void OnPlayerDeath()
    {
        if (CurrentState != State.Play) return;

        CurrentState = State.Loss;
        Debug.Log("Game Over");
        gameScreen.SetActive(false);
        loseScreen.SetActive(true);
    }

    public void OnFinish()
    {
        if (CurrentState != State.Play) return;

        CurrentState = State.Win;
        Debug.Log("You Win");
        gameScreen.SetActive(false);
        winScreen.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
