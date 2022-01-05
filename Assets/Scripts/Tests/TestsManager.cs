using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsManager : MonoBehaviour
{
    [SerializeField] private TestsUI _testsUi;
    [SerializeField] private List<TestsDataScriptable> _testsDataList;
    private GameManager _gameManager;
    //[SerializeField] private float _timeInSeconds;
    private int _correctAnswerCount = 0;
    private List<Question> _questions;
    private Question _selectedQuestion = new Question();
    //private float currentTime;

    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }
    /// <summary>
    /// ����� ���������� ��� �������� ������������ ������
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        bool correct = false;
        if (_selectedQuestion._correctAns == selectedOption)
        {
            //���� ����� ���������� �� ���� ++
            _correctAnswerCount++;
            correct = true;
            _testsUi.ScoreText.text = "����:" + _correctAnswerCount;
        }

        if (gameStatus == GameStatus.PLAYING)
        {
            //���� ������� ��� ��������, �� ����� ������, ���� ��� �� ����� ����
            if (_questions.Count > 0)
            {
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                _gameManager.GameEnd();
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

    private void Update()
    {
        //if (gameStatus == GameStatus.PLAYING)
        //{
        //    currentTime -= Time.deltaTime;
        //    SetTime(currentTime);
        //}
    }

    //void SetTime(float value)
    //{
    //    TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //����� � ��������
    //    _testsUi.TimerText.text = time.ToString("mm':'ss");   

    //    if (currentTime <= 0)
    //    {
    //        //���� ����� ����������� ����� ����
    //        GameEnd();
    //    }
    //}
    
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
