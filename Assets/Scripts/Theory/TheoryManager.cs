using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheoryManager : MonoBehaviour
{
    
    [SerializeField] private TheoryUI _theoryUi;
    public List<TheoryDataScriptable> _theoryDataList;
    private TheoryDataScriptable _dataScriptable;
    private string _currentDifficulty = "";

    // Start is called before the first frame update
    public void StartTheory(/*int difficultyIndex, string difficulty*/)
    {
        //_currentDifficulty = difficulty;
        //_dataScriptable = _theoryDataList[difficultyIndex];
        _theoryUi.DeriveTheory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
