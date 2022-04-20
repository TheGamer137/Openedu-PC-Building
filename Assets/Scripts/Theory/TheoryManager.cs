using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TheoryManager : MonoBehaviour
{
    
    [SerializeField] private TheoryUI _theoryUi;
    public List<TheoryDataScriptable> _theoryDataList;
    private TheoryDataScriptable _dataScriptable;
    // Start is called before the first frame update
    public void StartTheory(int theoryIndex)
    {
        _dataScriptable = _theoryDataList[theoryIndex];
        StartCoroutine(_theoryUi.ShowText(_dataScriptable));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
