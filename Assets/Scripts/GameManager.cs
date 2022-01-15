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
    public Button _beginnerBtn, _advancedBtn;
    public GameObject _gameOverPanel, _testText, _testOptions;
    private TestsManager _testsManager;
    private TheoryManager _theoryManager;
    private bool _gameIsPaused = false;
    //public void StartBeginnerLevel()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void StartAdvancedLevel()
    //{
    //    SceneManager.LoadScene(2);
    //}
    //public void ReturnToMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}

    public void StartGame()
    {
        _startButton.SetActive(false);
        _difficultyButton.SetActive(true);
        _mainMenuBackground.SetActive(false);
        _gameBackground.SetActive(true);
        
    }
    public void Pause()
    {
        _gameIsPaused = true;
        _pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        _gameIsPaused = false;
        _pauseMenu.SetActive(false);
    }
    public void SkipToTests()
    {
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
}
