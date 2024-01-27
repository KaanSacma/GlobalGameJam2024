using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest {
    public string Name;
    public bool IsCompleted;
}

public class QuestSystem : MonoBehaviour
{
    public List<Quest> QuestList;
    public int QuestIndex = 0;
    
    public void NextQuest()
    {
        if (QuestIndex < QuestList.Count - 1) {
            QuestIndex++;
        }
    }
    
    public void CompleteQuest()
    {
        QuestList[QuestIndex].IsCompleted = true;
    }
}
