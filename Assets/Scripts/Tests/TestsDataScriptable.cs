using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestsData", menuName = "Data/QuestionsData", order = 1)]
public class TestsDataScriptable : ScriptableObject
{
    public string _difficulty;
    public List<Question> _questions;
}