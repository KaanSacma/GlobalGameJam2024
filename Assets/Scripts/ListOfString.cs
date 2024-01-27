using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListOfString : MonoBehaviour
{
    public List<String> list;
    public int index = 0;

    private TextMeshProUGUI _text;
    
    public void Next()
    {
        if (index < list.Count - 1) {
            index++;
        } else {
            index = 0;
        }
    }
    
    public void Previous()
    {
        if (index > 0) {
            index--;
        } else {
            index = list.Count - 1;
        }
    }
    
    void Start()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    void Update()
    {
        _text.text = list[index];
    }
}
