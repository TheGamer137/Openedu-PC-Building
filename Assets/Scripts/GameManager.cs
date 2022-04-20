using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _difficultyButton, _pauseMenu, _gamePanel, _theoryPanel,
        _startButton, _mainMenuBackground, _gameBackground;
    [SerializeField] private TestsManager _testsManager;
    [SerializeField] private TheoryManager _theoryManager;
    private GameStatus _gameStatus;
    private bool _gameIsPaused = false;

    public void StartGame()
    {
        _startButton.SetActive(false);
        _difficultyButton.SetActive(true);
        _mainMenuBackground.SetActive(false);
        _gameBackground.SetActive(true);
        
    }
    public void SelectDifficulty(int difficultyIndex)
    {
        _theoryManager.StartTheory(difficultyIndex);
        _testsManager.StartTests(difficultyIndex);
        _difficultyButton.SetActive(false);
        _theoryPanel.SetActive(true) ;
    }
   
    public void Pause()
    {
        _gameIsPaused = true;
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        _gameIsPaused = false;
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
    public void SkipToTests()
    {
        Time.timeScale = 1;
        _gameStatus = GameStatus.TheoryFinished;
        _gameIsPaused = false;
        _pauseMenu.SetActive(false);
        _theoryPanel.SetActive(false);
        _gamePanel.SetActive(true);

    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
[SerializeField]
public enum GameStatus
{
    Playing,
    TheoryFinished,
    GameOver
}
