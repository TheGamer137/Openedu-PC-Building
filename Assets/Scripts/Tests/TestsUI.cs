using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestsUI : MonoBehaviour
{
    [SerializeField] private TestsManager _testsManager;
    [SerializeField] private Text _questionInfoText;
    [SerializeField] private List<Button> _options;
    private bool _answered = false;
    private Question _question;          //для хранения данных текущего вопроса

    private void Start()
    {
        for (int i = 0; i < _options.Count; i++)
        {
            Button localBtn = _options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
        

    }
    public void SetQuestion(Question question)
    {

        _question = question;
        _questionInfoText.text = question._testInfo;

        //перемешать варианты ответов
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question._options);
        for (int i = 0; i < _options.Count; i++)
        {
            _options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            _options[i].name = ansOptions[i];
        }
        _answered = false;

    }
    /// <summary>
    /// Method assigned to the buttons
    /// </summary>
    /// <param name="btn">ref to the button object</param>
    void OnClick(Button btn)
    {
        if (!_answered)
        {
            _answered = true;
            _testsManager.Answer(btn.name);
        }
    }
}