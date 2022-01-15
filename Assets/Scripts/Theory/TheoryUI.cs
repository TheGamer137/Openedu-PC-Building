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
    public float delay = 0.05f;
    private string _currentText = "";
    private bool _theoryIsStopped;

    public IEnumerator e;
    // Start is called before the first frame update
    void Start()
    {
        e = ShowTheory();
        StartCoroutine(e);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(e);
        }
    }

    IEnumerator ShowTheory()
    {
        foreach (var line in _TheoryData._TheoryList)
        {
            for (int i = 0; i < line.Length; i++)
            {
                _currentText = line.Substring(0, i);
                _theoryText.text = _currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(5);
        }
    }
}
