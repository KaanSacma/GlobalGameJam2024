using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Three : MonoBehaviour
{
    public bool stepOne = false;
    public GameObject stepOneObject;
    public bool stepTwo = false;
    public GameObject stepTwoObject;
    public GameObject stepThreeObject;
    public AudioClip clickGood;
    public AudioClip clickBad;
    private AudioSource Source;
    
    private QuestSystem _questSystem;

    
    public void StepOneComplete()
    {
        if (_questSystem.questIndex == 3 && !stepOne) {
            stepOneObject.SetActive(true);
            stepOne = true;
            
            Source.clip = clickGood;
            Source.Play();
        } else {
            Source.clip = clickBad;
            Source.Play();
        }
    }
    
    public void StepTwoComplete()
    {
        if (_questSystem.questIndex == 3 && stepTwo) {
            stepThreeObject.SetActive(true);
            stepTwo = true;
        }
    }
    
    public void CompleteQuest()
    {
        if (_questSystem.questIndex == 3) {
            _questSystem.NextQuest();
        }
    }
    
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        _questSystem = gameObject.GetComponent<QuestSystem>();
    }
    
    void Update()
    {
       if (_questSystem.questIndex == 3 && stepOne && !stepOneObject.activeSelf && !stepTwo && !stepTwoObject.activeSelf) {
           stepTwoObject.SetActive(true);
           stepTwo = true;
       }
       if (_questSystem.questIndex == 3 && stepOne && !stepOneObject.activeSelf && stepTwo && !stepTwoObject.activeSelf) {
           StepTwoComplete();
           CompleteQuest();
       }
    }
}
