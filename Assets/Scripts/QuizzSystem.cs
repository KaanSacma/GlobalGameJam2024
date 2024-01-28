using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Quizz {
    public string question;
    public string answer_a;
    public string answer_b;
    public string answer_c;
    public string answer_d;
    public string correct_answer;
}

public class QuizzSystem : MonoBehaviour
{
    public GameObject questTwo;
    public List<Quizz> quizzList;
    public int quizzIndex = 0;
    
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerAText;
    public TextMeshProUGUI answerBText;
    public TextMeshProUGUI answerCText;
    public TextMeshProUGUI answerDText;
    
    public GameObject answerAButton;
    public GameObject answerBButton;
    public GameObject answerCButton;
    public GameObject answerDButton;
    
    public Color defaultColor;
    

    private GameObject _correctAnswerButton;
    private bool _resetQuizz = false;
    private float _resetQuizzTimer = 0f;
    public void NextQuizz()
    {
        if (quizzIndex < quizzList.Count - 1) {
            quizzIndex++;
            UpdateQuizz();
        } else {
            gameObject.SetActive(false);
        }
    }
     
    public void UpdateQuizz()
    {
        questionText.text = quizzList[quizzIndex].question;
        answerAText.text = quizzList[quizzIndex].answer_a;
        answerBText.text = quizzList[quizzIndex].answer_b;
        answerCText.text = quizzList[quizzIndex].answer_c;
        answerDText.text = quizzList[quizzIndex].answer_d;
    }
    
    public void CheckAnswerA()
    {
        if (answerAText.text == quizzList[quizzIndex].correct_answer) {
            NextQuizz();
        } else {
            _resetQuizz = true;
            _correctAnswerButton = GetCorrectAnswerButton();
            _correctAnswerButton.GetComponent<Image>().color = Color.green;
        }
    }
    
    public void CheckAnswerB()
    {
        if (answerBText.text == quizzList[quizzIndex].correct_answer) {
            NextQuizz();
        } else {
            _resetQuizz = true;
            _correctAnswerButton = GetCorrectAnswerButton();
            _correctAnswerButton.GetComponent<Image>().color = Color.green;
        }
    }
    
    public void CheckAnswerC()
    {
        if (answerCText.text == quizzList[quizzIndex].correct_answer) {
            NextQuizz();
        } else {
            _resetQuizz = true;
            _correctAnswerButton = GetCorrectAnswerButton();
            _correctAnswerButton.GetComponent<Image>().color = Color.green;
        }
    }
    
    public void CheckAnswerD()
    {
        if (answerDText.text == quizzList[quizzIndex].correct_answer) {
            NextQuizz();
        } else {
            _resetQuizz = true;
            _correctAnswerButton = GetCorrectAnswerButton();
            _correctAnswerButton.GetComponent<Image>().color = Color.green;
        }
    }
    
    GameObject GetCorrectAnswerButton()
    {
        if (answerAText.text == quizzList[quizzIndex].correct_answer) {
            return answerAButton;
        } else if (answerBText.text == quizzList[quizzIndex].correct_answer) {
            return answerBButton;
        } else if (answerCText.text == quizzList[quizzIndex].correct_answer) {
            return answerCButton;
        } else if (answerDText.text == quizzList[quizzIndex].correct_answer) {
            return answerDButton;
        }
        
        return null;
    }
    
    void Start()
    {
        UpdateQuizz();
    }
    
    void Update()
    {
        if (_resetQuizz) {
            _resetQuizzTimer += Time.deltaTime;
            if (_resetQuizzTimer >= 2f) {
                _correctAnswerButton.GetComponent<Image>().color = defaultColor;
                _resetQuizz = false;
                _resetQuizzTimer = 0f;
                quizzIndex = 0;
                UpdateQuizz();
            }
        }
    }
}
