using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_One : MonoBehaviour
{
    public bool stepOne = false;
    public bool stepTwo = false;
    public bool stepThree = false;
    public GameObject stepOneObject;
    public GameObject stepTwoObject;
    public GameObject stepThreeObject;
    public AudioClip clickGood;
    public AudioClip clickBad;
    private AudioSource Source;
    
    private QuestSystem _questSystem;

    public void StepOneComplete()
    {
        Debug.Log(_questSystem.questIndex);
        if (_questSystem.questIndex == 0 || _questSystem.questIndex == 2 || _questSystem.questIndex == 4)
        {
            Source.clip = clickGood;
            Source.Play();
        } else {
            Source.clip = clickBad;
            Source.Play();
        }

        if (_questSystem.questIndex == 0 && !stepOne) {
            stepOneObject.SetActive(true);
            stepOne = true;
        } else if (_questSystem.questIndex == 2 && !stepTwo)
        {
            stepTwoObject.SetActive(true);
            stepTwo = true;
        }
        else if (_questSystem.questIndex == 4 && !stepThree)
        {
            stepThreeObject.SetActive(true);
            stepThree = true;
        }
    }
    
    public void CompleteQuest()
    {
        switch (_questSystem.questIndex)
        {
            case 0: _questSystem.NextQuest(); break;
            case 2: _questSystem.NextQuest(); break;
            case 4: _questSystem.NextQuest(); break;
        }
    }
    
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        _questSystem = gameObject.GetComponent<QuestSystem>();
    }
    
    void Update()
    {
        if (_questSystem.questIndex == 0 && stepOne && !stepOneObject.activeSelf) {
            CompleteQuest();
        } else if (_questSystem.questIndex == 2 && stepTwo && !stepTwoObject.activeSelf) {
            CompleteQuest();
        } else if (_questSystem.questIndex == 4 && stepThree && !stepThreeObject.activeSelf) {
            CompleteQuest();
        }
    }
}
