using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TheoryUI : MonoBehaviour
{
    [SerializeField] private Text _theoryText;
    [SerializeField] private GameObject _testsPanel, _theoryPanel;
    private GameStatus _gameStatus;
    public float delay = 0.05f;
    private string _currentText = "";
    private bool _theoryIsStopped = false;
    private bool isPressedLeft = false;
    private bool isPressedRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _theoryIsStopped = !_theoryIsStopped;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            isPressedLeft = true;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            isPressedRight = true;
    }
    private bool CheckIfRightButtonIsPressed(int i, int numberTheory)
    {
        if (isPressedRight && i < numberTheory - 1)
        {
            isPressedRight = false;
            _theoryIsStopped = true;
            return true;
        }
        return false;
    }

    private bool CheckIfLeftButtonIsPressed(int i, int numberTheory)
    {
        if (isPressedLeft && i > 0)
        {
            i -= 2;
            isPressedLeft = false;
            _theoryIsStopped = true;
            return true;
        }
        return false;
    }
    public IEnumerator ShowText(TheoryDataScriptable theoryDataScriptable)
    {
        var numberTheory = theoryDataScriptable._TheoryList.Count();
        for (int i = 0; i < numberTheory; i++)
        {
            var line = theoryDataScriptable._TheoryList[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (CheckIfRightButtonIsPressed(i, numberTheory))
                    break;
                if (CheckIfLeftButtonIsPressed(i, numberTheory))
                {
                    i -= 2;
                    break;
                }
                _currentText = line.Substring(0, j);
                _theoryText.text = _currentText;
                yield return new WaitForSeconds(delay);
                while (_theoryIsStopped)
                    yield return new WaitForSeconds(1);
                if (i == numberTheory - 1 && j == line.Length-1)
                {
                    _gameStatus = GameStatus.TheoryFinished;
                    _theoryPanel.SetActive(false);
                    _testsPanel.SetActive(true);
                }
            }
           
            while (!_theoryIsStopped) // не даст перелестнуть на следующаую часть теории, пока не нажмешь пробел
            {
                yield return new WaitForSeconds(1);
            }
            _theoryIsStopped = false;
        }
        while (!_theoryIsStopped) // не даст перелестнуть на следующаую часть теории, пока не нажмешь пробел
        {
            yield return new WaitForSeconds(1);
        }
        _theoryIsStopped = false;
        
    }
}
