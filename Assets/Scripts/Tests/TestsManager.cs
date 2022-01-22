using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsManager : MonoBehaviour
{
    [SerializeField] private TestsUI _testsUi;
    [SerializeField] private GameManager _gameManager;
    private TestsDataScriptable _dataScriptable;
    private string _currentDifficulty = "";
    public List<TestsDataScriptable> _testsDataList;
    private int _correctAnswerCount = 0;
    private List<Question> _questions;
    private Question _selectedQuestion;
    private GameStatus _gameStatus = GameStatus.NEXT;
    private Question selectedQuetion = new Question();

    public void StartTests(int difficultyIndex, string difficulty)
    {
        _currentDifficulty = difficulty;
        _correctAnswerCount = 0;
        _questions = new List<Question>();
        _dataScriptable = _testsDataList[difficultyIndex];
        _questions.AddRange(_dataScriptable._questions);
        SelectQuestion();
        _gameStatus = GameStatus.PLAYING;
    }
    /// <summary>
    /// ����� ���������� ��� �������� ������������ ������
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string answered)
    {
        bool correct = false;
        if (answered ==_selectedQuestion._correctAns)
        {
            //���� ����� ���������� �� ���� ++
            _correctAnswerCount++;
            correct = true;
        }
        if (_gameStatus == GameStatus.PLAYING)
        {
            if (_questions.Count > 0)
            {
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                EndTests();
            }
        }
        return correct;
    }

    /// <summary>
    /// ����� ��� ���������� ������ ������
    /// </summary>
    private void SelectQuestion()
    {
        int val = UnityEngine.Random.Range(0, _questions.Count);
        _selectedQuestion = _questions[val];
        _testsUi.SetQuestion(_selectedQuestion);

        _questions.RemoveAt(val);
    }

    void Update()
    {
        
    }
    private void EndTests()
    {
        _gameStatus = GameStatus.NEXT;
        _gameManager._testText.SetActive(false);
        _gameManager._testOptions.SetActive(false);
        _gameManager._gameOverPanel.SetActive(true);
        _testsUi._scoreText.text = "����:" + _correctAnswerCount;
        PlayerPrefs.SetInt(_currentDifficulty, _correctAnswerCount);
    }
}
[Serializable]
public class Question
{
    public string _testInfo;         //����������
    public QuestionType _testType;   //���
    public Sprite _testImage;        //�������� ���� ��� ����
    public List<string> _options;        //������� �����
    public string _correctAns;           //���������� �����
}
[Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE
}

[SerializeField]
public enum GameStatus
{
    PLAYING,
    NEXT
}
