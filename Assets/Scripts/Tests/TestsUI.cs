using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestsUI : MonoBehaviour
{
    [SerializeField] private TestsManager _testsManager;
    [SerializeField] private Text _scoreText;
    //[SerializeField] private Text _timerText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Image _questionImg;                     
    [SerializeField] private Text _questionInfoText;                 
    //[SerializeField] private List<Button> options;                  
    private Question _question;          //для хранения данных текущего вопроса
    private bool _answered = false;      //bool чтобы понять, если ответ получен или нет

    //public Text TimerText { get => timerText; }                     
    public Text ScoreText { get => _scoreText; }                     
    public GameObject GameOverPanel { get => _gameOverPanel; }                     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                break;
            
        }

        _questionInfoText.text = question._testInfo;                     

        //перемешать варианты ответов
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question._options);

        _answered = false;

    }

}
