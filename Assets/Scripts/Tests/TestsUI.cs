using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestsUI : MonoBehaviour
{
    [SerializeField] private TestsManager _testsManager;
    [SerializeField] private Image _questionImg;                     
    [SerializeField] private Text _questionInfoText;
    [SerializeField] private List<Button> _options;
    [SerializeField] private GameManager _beginnerBtnPrefab, _advancedBtnPrefab;
    [SerializeField] private GameObject _buttonPosition, _gameMenu, _difficultyButton, _textbox, _theoryPanel;
    private TheoryManager _theoryManager;
    public TheoryUI _TheoryUi;
    private GameManager _gameManager;
    public Text _scoreText;
    private Question _question;          //для хранения данных текущего вопроса
    private bool _answered = false;      //bool чтобы понять, если ответ получен или нет                                   
    // Start is called before the first frame update
    private void Start()
    {
        _difficultyButton.SetActive(false);
        for (int i = 0; i < _options.Count; i++)
        {
            Button localBtn = _options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
        CreateDifficultyButtons();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    
    public void SetQuestion(Question question)
    {
        _question = question;
        switch (question._testType)
        {
            case QuestionType.TEXT:
                _questionImg.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                _questionImg.transform.parent.gameObject.SetActive(true);
                _questionImg.transform.gameObject.SetActive(true);
                _questionImg.sprite = question._testImage;
                break;
        }

        _questionInfoText.text = question._testInfo;                     

        //перемешать варианты ответов
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question._options);
        //var difference = Math.Abs(_options.Count - ansOptions.Count);
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
            bool val = _testsManager.Answer(btn.name);
        }
    }
    /// <summary>
    /// Метод для динамического создания кнопок
    /// </summary>
    void CreateDifficultyButtons()
    {

        for (int i = 0; i < _testsManager._testsDataList.Count; i++)
        {
            GameManager beginnerButton = Instantiate(_beginnerBtnPrefab, _buttonPosition.transform);
            GameManager advancedButton = Instantiate(_advancedBtnPrefab, _buttonPosition.transform);
            int index = i;
            beginnerButton._beginnerBtn.onClick.AddListener(() => SetDifficulty(index, _testsManager._testsDataList[index]._difficulty));
        }
    }
    private void SetDifficulty(int index, string difficulty)
    {
        _testsManager.StartTests(index, difficulty);
        _textbox.SetActive(true);
        //_theoryManager.StartTheory(index, difficulty);
        //_gameMenu.SetActive(true);
        _buttonPosition.SetActive(false);
        _theoryPanel.SetActive(true);


    }
}
