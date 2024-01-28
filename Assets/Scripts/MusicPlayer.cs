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
        SetMusicInfo();
        _audioSource.time = 0f;
        _audioSource.Play();
    }
    
    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void NextMusic()
    {
        if (musicIndex < musicList.Count - 1) {
            musicIndex++;
        } else {
            musicIndex = 0;
            StopMusic();
            gameObject.transform.parent.gameObject.SetActive(false);
            return;
        }
        _audioSource.Stop();
        PlayMusic();
    }

    public void ShuffleList()
    {
        int n = musicList.Count;
        System.Random rng = new System.Random();

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Music value = musicList[k];
            musicList[k] = musicList[n];
            musicList[n] = value;
        }
    }

    void Start()
    {
        _spriteRenderer = GameObject.Find("Image Music").GetComponent<Image>();
       _audioTitleText = GameObject.Find("Title Music").GetComponent<TextMeshProUGUI>();
       _audioArtistText = GameObject.Find("Artist Music").GetComponent<TextMeshProUGUI>();
       _slider = GameObject.Find("Slider Music").GetComponent<Slider>();
       _audioSource = gameObject.GetComponent<AudioSource>();

        ShuffleList();

       SetMusicInfo();
    }
    
    void Update()
    {
        if (_audioSource.time >= _audioSource.clip.length) {
            musicIndex = 0;
            _audioSource.Stop();
            SetMusicInfo();
        }
        if (gameObject.transform.parent.gameObject.activeSelf && !_audioSource.isPlaying) {
            PlayMusic();
        } else if (!gameObject.transform.parent.gameObject.activeSelf) {
            _audioSource.Stop();
        }

        _slider.value = _audioSource.time / _audioSource.clip.length;
    }
}
