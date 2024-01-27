using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSystem : MonoBehaviour
{
    public List<String> textList;
    public int textSpeed = 1;
    public String textToDisplay;
    public float timeToWait = 0.1f;
    
    private TextMeshProUGUI _textMesh;
    private int _index = 0;
    private int _stringIndex = 0;
    private float _timer = 0f;
    private int _acceleration = 1;
    
    public void NextText()
    {
        if (_index < textList.Count - 1) {
            _index++;
            textToDisplay = "";
            _stringIndex = 0;
            _timer = 0f;
            _acceleration = 1;
        } else {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
    
    public void Accelerate()
    {
        if (textToDisplay.Length >= textList[_index].Length) {
            NextText();
            return;
        }
        _acceleration = 2;
        _timer = timeToWait;
    }

    private void Start()
    {
        _textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!gameObject.activeSelf)
            return;
        _timer += Time.deltaTime;
        
        if (textToDisplay.Length < textList[_index].Length && _timer > timeToWait) {
            _stringIndex += textSpeed * _acceleration;
            if (_stringIndex > textList[_index].Length) {
                _stringIndex = textList[_index].Length;
            }
            textToDisplay = textList[_index].Substring(0, _stringIndex);
            if (_acceleration == 2) {
                _acceleration = 1;
            }
            _timer = 0f;
            _textMesh.text = textToDisplay;
        }
    }
}
