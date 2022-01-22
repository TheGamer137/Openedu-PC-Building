using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShuffleList
{
    public static List<E> ShuffleListItems<E>(List<E> inputList)
    {
        List<E> originalList = new List<E>();
        originalList.AddRange(inputList);
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        int randomIndex = 0;
        while (originalList.Count > 0)
        {
            randomIndex = r.Next(0, originalList.Count); //¬ыбирает рандомный объект в листе
            randomList.Add(originalList[randomIndex]); //добавл€ет в новый раедомный лист
            originalList.RemoveAt(randomIndex); //дл€ избежани€ дубликатов удал€ем
        }

        return randomList; //возвращаем новый рандомный лист
    }
}