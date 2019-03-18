using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioClip[] se;
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
        this.GetComponent<AudioSource>().clip = se[id];
        this.GetComponent<AudioSource>().Play();

    }
    void StopSound(int id)
    {
        this.GetComponent<AudioSource>().clip = se[id];
        this.GetComponent<AudioSource>().Stop();
    }
}
