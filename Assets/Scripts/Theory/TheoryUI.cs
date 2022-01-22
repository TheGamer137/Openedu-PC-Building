using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TheoryUI : MonoBehaviour
{
    [SerializeField] private TheoryDataScriptable _TheoryData;
    [SerializeField] private Text _theoryText;
    private GameManager _gameManager;
    public float delay = 0.01f;
    private string _currentText = "";
    private bool _theoryIsStopped;
    private bool isPressedLeft;
    private bool isPressedRight;

    public IEnumerator e;
    // Start is called before the first frame update
    void Start()
    {
        _theoryIsStopped = false;
        isPressedLeft = false;
        isPressedRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StopCoroutine(e);
            _theoryIsStopped = !_theoryIsStopped;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            isPressedLeft = true;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            isPressedRight = true;
    }

    public void DeriveTheory()
    {
        e = ShowTheory();
        StartCoroutine(e);
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

    IEnumerator ShowTheory()
    {
        var numberTheory = _TheoryData._TheoryList.Count();
        for (int i = 0; i < numberTheory; i++)
        {
            var line = _TheoryData._TheoryList[i];
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
        //_gameManager.SkipToTests();
    }
}
