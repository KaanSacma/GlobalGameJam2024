using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSystem : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private DateTime _now;
    private String _date;
    private String _time;
    
    void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _now = DateTime.Now;
        _date = _now.ToString("dd/MM/yyyy");
        _time = _now.ToString("HH:mm");
        _text.text = _time + "\n" + _date;
    }
}
