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
    /// ћетод вызываетс€ дл€ проверки правильности ответа
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        bool correct = false;
        if (_selectedQuestion._correctAns == selectedOption)
        {
            //≈сли ответ правильный то счет ++
            _correctAnswerCount++;
            correct = true;
            _testsUi.ScoreText.text = "—чет:" + _correctAnswerCount;
        }

        if (gameStatus == GameStatus.PLAYING)
        {
            //если вопросы еще остались, то новый вопрос, если нет то конец игры
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
    /// ћетод дл€ случайного выбора тестов
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
    //    TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //врем€ в секундах
    //    _testsUi.TimerText.text = time.ToString("mm':'ss");   

    //    if (currentTime <= 0)
    //    {
    //        //если врем€ закончилось конец игры
    //        GameEnd();
    //    }
    //}
    
}
[Serializable]
public class Question
{
    public string _testInfo;         //текст“еста
    public QuestionType _testType;   //тип
    public Sprite _testImage;        //картинка если она есть
    public List<string> _options;        //вариант ответ
    public string _correctAns;           //правильный ответ
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
