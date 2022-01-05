using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _difficultyButton;
    [SerializeField] private GameObject _advancedButton;
    [SerializeField] private GameObject _beginnerButton;
    [SerializeField] private TestsUI _testsUi;
    [SerializeField] private List<TestsDataScriptable> _testsDataList;
    [SerializeField] private TestsManager _testsManager;
    [SerializeField] private float _timeInSeconds;
    private string _currentCategory = "";
    private int _correctAnswerCount = 0;
    private List<Question> _questions;
    private TestsDataScriptable dataScriptable;

    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }
    public void StartGame(int categoryIndex, string category)
    {
        _currentCategory = category;
        _correctAnswerCount = 0;
        //currentTime = _timeInSeconds;
        //добавляет данные из скриптабла
        _questions = new List<Question>();
        dataScriptable = _testsDataList[categoryIndex];
        _questions.AddRange(dataScriptable._questions);
        //выбор вопроса оттуда
        ;
        gameStatus = GameStatus.PLAYING;
    }
    public void GameEnd()
    {
        gameStatus = GameStatus.NEXT;
        _testsUi.GameOverPanel.SetActive(true);

        //Сохранить счет
        PlayerPrefs.SetInt(_currentCategory, _correctAnswerCount);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBeginnerLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void StartAdvancedLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void ChooseDifficulty()
    {
        _difficultyButton.SetActive(false);
        _beginnerButton.SetActive(true);
        _advancedButton.SetActive(true);
    }
}
