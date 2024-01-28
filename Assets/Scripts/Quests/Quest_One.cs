using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_One : MonoBehaviour
{
    public bool stepOne = false;
    public GameObject stepOneObject;
    public AudioClip clickGood;
    public AudioClip clickBad;
    private AudioSource Source;
    
    private QuestSystem _questSystem;

    public void StepOneComplete()
    {
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
        Source = gameObject.GetComponent<AudioSource>();
        _questSystem = gameObject.GetComponent<QuestSystem>();
    }
    
    void Update()
    {
        if (_questSystem.questIndex == 0 && stepOne && !stepOneObject.activeSelf) {
            CompleteQuest();
        }
    }
}
