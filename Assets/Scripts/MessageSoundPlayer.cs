using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSoundPlayer : MonoBehaviour
{
    public AudioClip Sound;
    private AudioSource Source;

    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        Source.clip = Sound;

        Source.Play();

        gameObject.transform.position = new Vector3(-10000,-10000);
    }
}
