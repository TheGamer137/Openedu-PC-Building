using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TheoryData", menuName = "Data/TheoryData", order = 1)]
public class TheoryDataScriptable : ScriptableObject
{
    //public string _difficulty;
    [TextArea(5, 20)]
    public List<string> _TheoryList;
}