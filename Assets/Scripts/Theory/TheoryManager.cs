using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheoryManager : MonoBehaviour
{
    [SerializeField] private TheoryUI _theoryUi;
    [SerializeField] private List<TheoryDataScriptable> _theoryDataScriptablesDataList;
    [SerializeField] public List<Theory> _TheoryList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Theory
{
    public List<string> _theoryLines;
}
