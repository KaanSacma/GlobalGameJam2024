using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioSource> musicList;
    public List<Sprite> musicImageList;
    public int musicIndex = 0;
    public bool isPlaying = false;
    public bool isLooping = false;
    public int musicTextSpeed = 1;
    
    private AudioSource _audioSource;
    private Image _spriteRenderer;
    private Slider _slider;
    private float _currentTime = 0f;
    private TextMeshProUGUI _audioTimeText;
    private TextMeshProUGUI _audioNameText;
    
    private void SetMusicInfo()
    {
        int minutes = Mathf.FloorToInt(_audioSource.clip.length / 60);
        int seconds = Mathf.FloorToInt(_audioSource.clip.length % 60);
        _audioTimeText.text = minutes.ToString() + ":" + seconds.ToString();
        _audioNameText.text = _audioSource.clip.name;
        _spriteRenderer.sprite = musicImageList[musicIndex];
    }
    
    public void PlayMusic()
    {
        if (!isPlaying) {
            _audioSource = musicList[musicIndex];
            _spriteRenderer.sprite = musicImageList[musicIndex];
            _audioSource.time = _currentTime;
            SetMusicInfo();
            _audioSource.Play();
            isPlaying = true;
        } else {
            _currentTime = _audioSource.time;
            _audioSource.Stop();
            isPlaying = false;
        }
    }
    
    public void NextMusic()
    {
        if (musicIndex < musicList.Count - 1) {
            musicIndex++;
        } else {
            musicIndex = 0;
        }
        if (isPlaying) {
            _audioSource.Stop();
            _audioSource.clip = musicList[musicIndex].clip;
            _currentTime = 0f;
            SetMusicInfo();
            _audioSource.Play();
        }
    }
    
    public void PreviousMusic()
    {
        if (musicIndex > 0) {
            musicIndex--;
        } else {
            musicIndex = musicList.Count - 1;
        }
        if (isPlaying) {
            _audioSource.Stop();
            _audioSource.clip = musicList[musicIndex].clip;
            _currentTime = 0f;
            SetMusicInfo();
            _audioSource.Play();
        }
    }
    
    public void LoopMusic()
    {
        isLooping = isLooping ? false : true;
        _audioSource.loop = isLooping;
    }
    
    void Start()
    {
       _audioTimeText = GameObject.Find("Time Music").GetComponent<TextMeshProUGUI>();
       _audioNameText = GameObject.Find("Name Music").GetComponent<TextMeshProUGUI>();
       _spriteRenderer = GameObject.Find("Image Music").GetComponent<Image>();
       _slider = GameObject.Find("Slider Music").GetComponent<Slider>();
       _audioSource = musicList[musicIndex];
       SetMusicInfo();
    }
    
    void Update()
    {
        if (isPlaying) {
            _slider.value = _audioSource.time / _audioSource.clip.length;
        }
        if (isPlaying && _audioSource.time >= _audioSource.clip.length) {
            if (isLooping) {
                _audioSource.time = 0f;
            } else {
                NextMusic();
            }
        }
    }
}
