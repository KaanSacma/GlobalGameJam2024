using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Two : MonoBehaviour
{
    public bool stepOne = false;
    public GameObject stepOneObject;
    public bool stepTwo = false;
    public GameObject stepTwoObject;
    public GameObject stepThreeObject;
    
    private QuestSystem _questSystem;

    
    public void StepOneComplete()
    {
        if (_questSystem.questIndex == 1) {
            stepOneObject.SetActive(true);
            stepOne = true;
        }
    }
    
    public void StepTwoComplete()
    {
        if (_questSystem.questIndex == 1) {
            stepThreeObject.SetActive(true);
            stepTwo = true;
        }
    }
    
    public void CompleteQuest()
    {
        if (_questSystem.questIndex == 1) {
            _questSystem.NextQuest();
        }
    }
    
    void Start()
    {
        _questSystem = gameObject.GetComponent<QuestSystem>();
    }
    
    void Update()
    {
       if (_questSystem.questIndex == 1 && stepOne && !stepOneObject.activeSelf && !stepTwo && !stepTwoObject.activeSelf) {
           stepTwoObject.SetActive(true);
           stepTwo = true;
       }
       if (_questSystem.questIndex == 1 && stepOne && !stepOneObject.activeSelf && stepTwo && !stepTwoObject.activeSelf) {
           StepTwoComplete();
           CompleteQuest();
       }
    }
}
