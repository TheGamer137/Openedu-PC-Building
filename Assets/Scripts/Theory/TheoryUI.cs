using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TheoryUI : MonoBehaviour
{
    private Theory _theory;
    public float delay = 0.1f;
    public string _fullText;
    private string _currentText = "";

    private bool _skip = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!_skip)
        { 
            StartCoroutine(ShowTheory());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _skip = true;
            SkipTheory();
        }
    }

    IEnumerator ShowTheory()
    {
        foreach (var line in _theory._theoryLines)
        {
            for (int i = 0; i < _fullText.Length; i++)
            {
                _currentText = _fullText.Substring(0, i);
                this.GetComponent<Text>().text = _currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }
    void SkipTheory()
    {
        var lastLine = _currentText.Last();
    }
}
