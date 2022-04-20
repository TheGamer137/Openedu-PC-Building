using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestsManager : MonoBehaviour
{
    [SerializeField] private TestsUI _testsUi;
    [SerializeField] private TheoryUI _theoryUI;
    [SerializeField] private GameObject _testsPanel, _gameOverPanel;
    [SerializeField] private Text _scoreText;
    private string _currentDifficulty = "";
    private GameStatus _gameStatus;
    private List<Question> _questions;
    public List<TestsDataScriptable> _testsDataList;
    private TestsDataScriptable _dataScriptable;
    private Question _selectedQuestion = new Question();
    private int _correctAnswerCount = 0;

    public void StartTests(int difficultyIndex)
    {
        _correctAnswerCount = 0;
        _questions = new List<Question>();
        _dataScriptable = _testsDataList[difficultyIndex];
        _questions.AddRange(_dataScriptable._questions);
        SelectQuestion();
        if(_gameStatus == GameStatus.TheoryFinished)
        {
            _testsPanel.SetActive(true);
        }
    }
    /// <summary>
    /// Метод для случайного выбора тестов
    /// </summary>
    private void SelectQuestion()
    {
        int val = UnityEngine.Random.Range(0, _questions.Count);
        _selectedQuestion = _questions[val];
        _testsUi.SetQuestion(_selectedQuestion);

        _questions.RemoveAt(val);
    }
    /// <summary>
    /// Метод вызывается для проверки правильности ответа
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string answered)
    {
        bool correct = false;
        if (answered == _selectedQuestion._correctAns)
        {
            //Если ответ правильный то счет ++
            _correctAnswerCount++;
            correct = true;
        }
        if (_questions.Count > 0)
        {
            SelectQuestion();
        }
        else
        {
            EndTests();
        }
        return correct;
    }
    private void EndTests()
    {
        _gameStatus = GameStatus.GameOver;
        _testsPanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        _scoreText.text = "Счет: " + _correctAnswerCount;
        PlayerPrefs.SetInt(_currentDifficulty, _correctAnswerCount);
    }
}

[Serializable]
public class Question
{
    public string _testInfo;         //текстТеста
    public List<string> _options;        //вариант ответ
    public string _correctAns;           //правильный ответ
}

