using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSounds : MonoBehaviour
{
    public AudioClip[] audios;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlaySound(int id)
    {
        this.GetComponent<AudioSource>().clip = audios[id];
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            if (id == 2)
            {
                this.GetComponent<AudioSource>().loop = true;
                this.GetComponent<AudioSource>().Play();
            }
        }
        if (id == 1)
        {
            Debug.Log(id);
            this.GetComponent<AudioSource>().loop = false;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void StopSound(int id)
    {
        this.GetComponent<AudioSource>().clip = audios[id];
        this.GetComponent<AudioSource>().Stop();
    }
}
