using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TheoryData", menuName = "Data/TheoryData", order = 1)]
public class TheoryDataScriptable : ScriptableObject
{
    [TextArea(5, 20)]
    public List<string> _TheoryList;
}