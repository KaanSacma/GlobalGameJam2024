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
    public List<Quest> questList;
    public int questIndex = 0;
    
    public void NextQuest()
    {
        if (questIndex < questList.Count - 1) {
            CompleteQuest();
            questIndex++;
        }
    }
    
    public void CompleteQuest()
    {
        questList[questIndex].IsCompleted = true;
    }
}
