using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Simon {
    public GameObject button;
    public Color defaultColor;
    public Color desactivatedColor;
    public AudioClip sound;
}

public class SimonSystem : MonoBehaviour
{
    public List<Simon> simonList;
    public int numberOfRounds = 5;
    public int currentRound = 0;
    public float simonTimerMax = 1f;
    public bool canAnswer = false;
    
    private List<Simon> _simonSequence;
    private int _simonIndex = 0;
    private float _simonTimer = 0f;
    private int _simonIndexCheck = -1;
    private AudioSource _audioSource;

    public void CheckAnswer(int index)
    {
        if (canAnswer && _simonIndexCheck == -1) {
            _simonIndexCheck = index;
        }
        if (canAnswer && _simonIndexCheck != -1 && _simonSequence[_simonIndex].button == simonList[index].button) {
            _simonIndex++;
        } else if (canAnswer && _simonSequence[_simonIndex].button != simonList[index].button) {
            _simonIndexCheck = -1;
            _simonIndex = 0;
            currentRound = 0;
            canAnswer = false;
        }
    }
    
    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _simonSequence = new List<Simon>();
        for (int i = 0; i < simonList.Count; i++) {
            simonList[i].button.GetComponent<Image>().color = simonList[i].desactivatedColor;
        }
        for (int i = 0; i < numberOfRounds; i++) {
            _simonSequence.Add(simonList[UnityEngine.Random.Range(0, simonList.Count)]);
        }
    }
    
    private void Update()
    {
        if (currentRound >= numberOfRounds) {
            gameObject.SetActive(false);
        }
        if (!canAnswer) {
            _simonTimer += Time.deltaTime;
            if (_simonTimer >= simonTimerMax && _simonSequence[_simonIndex].button.GetComponent<Image>().color != _simonSequence[_simonIndex].defaultColor) {
                _simonSequence[_simonIndex].button.GetComponent<Image>().color = _simonSequence[_simonIndex].defaultColor;
                _audioSource.clip = _simonSequence[_simonIndex].sound;
                _audioSource.Play();
                _simonTimer = 0f;
            }

            if (_simonTimer >= simonTimerMax && _simonIndex <= currentRound) {
                _simonTimer = 0f;
                _simonSequence[_simonIndex].button.GetComponent<Image>().color = _simonSequence[_simonIndex].desactivatedColor;
                _audioSource.Stop();
                _simonIndex++;
            }
            if (_simonIndex > currentRound) {
                _simonTimer = 0f;
                _simonIndex = 0;
                canAnswer = true;
            }
        } else if (canAnswer && _simonIndexCheck != -1) {
            _simonTimer += Time.deltaTime;
            if (simonList[_simonIndexCheck].button.GetComponent<Image>().color != simonList[_simonIndexCheck].defaultColor) {
                simonList[_simonIndexCheck].button.GetComponent<Image>().color = simonList[_simonIndexCheck].defaultColor;
                _audioSource.clip = simonList[_simonIndexCheck].sound;
                _audioSource.Play();
            }

            if (_simonTimer >= simonTimerMax) {
                _simonTimer = 0f;
                simonList[_simonIndexCheck].button.GetComponent<Image>().color = simonList[_simonIndexCheck].desactivatedColor;
                _audioSource.Stop();
                _simonIndexCheck = -1;
                if (_simonIndex > currentRound) {
                    currentRound++;
                    _simonIndex = 0;
                    canAnswer = false;
                }
            }
        }
    }
}
