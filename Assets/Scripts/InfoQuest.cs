using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoQuest : MonoBehaviour
{
    public QuestSystem questSystem;
    private TextMeshProUGUI _questName;
    
    void Update()
    {
        _questName.text = questSystem.questList[questSystem.questIndex].name;
    }

    private void Start()
    {
        _questName = GetComponent<TextMeshProUGUI>();
        _questName.text = questSystem.questList[questSystem.questIndex].name;
    }
}
