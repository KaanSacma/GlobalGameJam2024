using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPlaylist : MonoBehaviour
{
    public MusicPlayer musicPlayer;
    public TextMeshProUGUI choicePlayist;
    
    public void Check()
    {
        if (musicPlayer.musicList[musicPlayer.musicIndex].playlist == choicePlayist.text) {
            musicPlayer.StopMusic();
            musicPlayer.NextMusic();
        } else {
            musicPlayer.StopMusic();
            musicPlayer.musicIndex = 0;
            musicPlayer.PlayMusic();
        }
    }
}
