using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_One : MonoBehaviour
{
    public bool stepOne = false;
    public GameObject stepOneObject;
    
    private QuestSystem _questSystem;

    public void StepOneComplete()
    {
        if (_questSystem.questIndex == 0) {
            stepOneObject.SetActive(true);
            stepOne = true;
        }
    }
    
    public void CompleteQuest()
    {
        if (_questSystem.questIndex == 0) {
            _questSystem.NextQuest();
        }
    }
    
    void Start()
    {
        _questSystem = gameObject.GetComponent<QuestSystem>();
    }
    
    void Update()
    {
        if (stepOne && !stepOneObject.activeSelf) {
            CompleteQuest();
        }
    }
}
