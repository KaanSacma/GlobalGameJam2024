using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPlaylist : MonoBehaviour
{
    public MusicPlayer musicPlayer;
    public TextMeshProUGUI choicePlayist;
    public AudioClip goodClick;
    public AudioClip badClick;

    private AudioSource _source;


    private void Start()
    {
        _source = gameObject.GetComponent<AudioSource>();
    }

    public void Check()
    {
        if (musicPlayer.musicList[musicPlayer.musicIndex].playlist == choicePlayist.text) {

            _source.clip = goodClick;
            _source.Play();
            musicPlayer.StopMusic();
            musicPlayer.NextMusic();
        } else {
            _source.clip = badClick;
            _source.Play();
            musicPlayer.StopMusic();
            musicPlayer.ShuffleList();
            musicPlayer.musicIndex = 0;
            musicPlayer.PlayMusic();
        }
    }
}
