using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class Music
{
    public String name;
    public String artist;
    public String playlist;
    public Sprite image;
    public AudioClip clip;
}

public class MusicPlayer : MonoBehaviour
{
    public List<Music> musicList;
    public int musicIndex = 0;
    
    private AudioSource _audioSource;
    private Image _spriteRenderer;
    private Slider _slider;
    private float _currentTime = 0f;
    private TextMeshProUGUI _audioTitleText;
    private TextMeshProUGUI _audioArtistText;
    
    private void SetMusicInfo()
    {
        _audioSource.clip = musicList[musicIndex].clip;
        _audioTitleText.text = musicList[musicIndex].name;
        _audioArtistText.text = musicList[musicIndex].artist;
        _spriteRenderer.sprite = musicList[musicIndex].image;
    }
    
    public void PlayMusic()
    {
        _audioSource.time = _currentTime;
        SetMusicInfo();
        _audioSource.Play();
    }
    
    public void NextMusic()
    {
        if (musicIndex < musicList.Count - 1) {
            musicIndex++;
        } else {
            musicIndex = 0;
            //TODO: Close the app
        }
        _audioSource.Stop();
        _currentTime = 0f;
        SetMusicInfo();
        _audioSource.Play();
    }
    
    void Start()
    {
        _spriteRenderer = GameObject.Find("Image Music").GetComponent<Image>();
       _audioTitleText = GameObject.Find("Title Music").GetComponent<TextMeshProUGUI>();
       _audioArtistText = GameObject.Find("Artist Music").GetComponent<TextMeshProUGUI>();
       _slider = GameObject.Find("Slider Music").GetComponent<Slider>();
       _audioSource = gameObject.GetComponent<AudioSource>();
       SetMusicInfo();
    }
    
    void Update()
    {
        _slider.value = _audioSource.time / _audioSource.clip.length;
        if (_audioSource.time >= _audioSource.clip.length) {
            // TODO: Restart from start
        }
    }
}
